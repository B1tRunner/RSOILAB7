using Shipments_of_building_materials_;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace MaterialShipmentApp
{
    public partial class MaterialShipmentForm : Form
    {
        private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=BuildingMaterialsDb;
                                            Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        private List<Material> materials = new List<Material>();
        public MaterialShipmentForm()
        {
            InitializeComponent();
            LoadMaterialNames();
        }

        private void LoadMaterialNames()
        {
            materialComboBox.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Id, Title, Num, Cost FROM Material";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var material = new Material
                        {
                            Id = (int)reader["Id"],
                            Title = (string)reader["Title"],
                            Num = (int)reader["Num"],
                            Cost = (double)reader["Cost"]
                        };
                        materials.Add(material);
                        materialComboBox.Items.Add(material.FullInfo);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при загрузке списка материалов: " + ex.Message, 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sellButton_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                DateTime dealTime = dealTimeDateTimePicker.Value;
                var selectedMaterial = GetMaterialToSell(materialComboBox.SelectedItem.ToString());
                int materialId = selectedMaterial.Id;
                int numOfMaterials = Convert.ToInt32(numOfMaterialsTextBox.Text);
                string customerName = customerNameTextBox.Text;

                if (selectedMaterial.Cost == null)
                {
                    throw new ArgumentNullException();
                }

                var totalCost = CalculateTotalCost(selectedMaterial.Title, 
                    selectedMaterial.Cost, numOfMaterials);

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "INSERT INTO Shipment (Id, DealTime, MaterialId, " +
                            "NumOfMaterials, CustomerName, TotalCost) " +
                            "VALUES (@Id, @DealTime, @MaterialId, " +
                            "@NumOfMaterials, @CustomerName, @TotalCost)";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Id", GenerateRandomId());
                        command.Parameters.AddWithValue("@DealTime", dealTime);
                        command.Parameters.AddWithValue("@MaterialId", materialId);
                        command.Parameters.AddWithValue("@NumOfMaterials", numOfMaterials);
                        command.Parameters.AddWithValue("@CustomerName", customerName);
                        command.Parameters.AddWithValue("@TotalCost", totalCost);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Отгрузка успешно добавлена.", "Успех", MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
                        ClearInputFields();

                        Shipment shipment = new Shipment
                        {
                            MaterialId = materialId,
                            NumOfMaterials = numOfMaterials
                        };
                        UpdateMaterialTableWithNewShipment(shipment);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка при добавлении отгрузки: " + ex.Message, "Ошибка", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LoadMaterialNames();
            }
        }

        private void UpdateMaterialTableWithNewShipment(Shipment shipment)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Material SET Num = Num - @NumOfMaterials WHERE Id = @MaterialId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NumOfMaterials", shipment.NumOfMaterials);
                    command.Parameters.AddWithValue("@MaterialId", shipment.MaterialId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при обновлении таблицы материалов: " + ex.Message, 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (materialComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите материал.", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(numOfMaterialsTextBox.Text))
            {
                MessageBox.Show("Введите количество материалов.", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(numOfMaterialsTextBox.Text, out int numOfMaterials))
            {
                MessageBox.Show("Неверный формат количества материалов.", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(customerNameTextBox.Text))
            {
                MessageBox.Show("Введите имя клиента.", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private double CalculateTotalCost(string materialName, double? materialCost, int numOfMaterials)
        {
            if (materialCost == null)
            {
                return 0;
            }
            else
            {
                var totalCost = materialCost * numOfMaterials;
                return (double)totalCost;
            }
        }

        private void ClearInputFields()
        {
            dealTimeDateTimePicker.Value = DateTime.Now;
            materialComboBox.SelectedIndex = -1;
            numOfMaterialsTextBox.Text = "";
            customerNameTextBox.Text = "";
        }

        private Material GetMaterialToSell(string chosenMaterial)
        {
            var id = GetMaterialId(chosenMaterial);
            var material = materials.FirstOrDefault(m => m.Id == id);

            return material;
        }

        private int GetMaterialId(string chosenMaterial)
        {
            var id = chosenMaterial.Split(' ')[1];
            id = id.Split(',')[0];
            id = id.Trim();
            return int.Parse(id);
        }

        public int GenerateRandomId()
        {
            Random random = new Random();
            return random.Next(10000);
        }
    }

}