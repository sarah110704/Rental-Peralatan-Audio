using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UAS_PBO.model;

namespace UAS_PBO.controller
{
    internal class EquipmentController
    {
        private Connection koneksi = new Connection();

        // ✅ Method untuk mendapatkan semua data equipment
        public List<Equipment> GetAllEquipment()
        {
            List<Equipment> equipmentList = new List<Equipment>();
            try
            {
                koneksi.OpenConnection();
                var result = koneksi.reader("SELECT * FROM Equipment");

                while (result.Read())
                {
                    Equipment equipment = new Equipment(
                        result.GetInt32("id"),
                        result.GetString("name"),
                        result.GetString("category"),
                        result.GetString("brand"),
                        result.GetDecimal("rental_price"),
                        result.GetInt32("stock"),
                        result.GetString("description"),
                        result.GetString("image_path"),
                        result.GetString("status")
                    );
                    equipmentList.Add(equipment);
                }
                result.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return equipmentList;
        }

        // ✅ Method untuk menambahkan equipment baru
        public bool InsertEquipment(Equipment equipment)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();
                koneksi.ExecuteQueries("INSERT INTO Equipment (name, category, brand, rental_price, stock, description, image_path, status) " +
                    "VALUES ('" + equipment.Name + "', '" + equipment.Category + "', '" + equipment.Brand + "', '" + equipment.RentalPrice +
                    "', '" + equipment.Stock + "', '" + equipment.Description + "', '" + equipment.ImagePath + "', '" + equipment.Status + "')");

                status = true;
                MessageBox.Show("Data berhasil ditambahkan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal Insert Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }

        // ✅ Method untuk memperbarui data equipment
        public bool UpdateEquipment(Equipment equipment)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();
                koneksi.ExecuteQueries("UPDATE Equipment SET name='" + equipment.Name + "', category='" + equipment.Category +
                    "', brand='" + equipment.Brand + "', rental_price='" + equipment.RentalPrice + "', stock='" + equipment.Stock +
                    "', description='" + equipment.Description + "', image_path='" + equipment.ImagePath + "', status='" + equipment.Status +
                    "' WHERE id=" + equipment.Id);

                status = true;
                MessageBox.Show("Data berhasil diperbarui", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal Update Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }

        // ✅ Method untuk menghapus data equipment berdasarkan ID
        public bool DeleteEquipment(int id)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();
                koneksi.ExecuteQueries("DELETE FROM Equipment WHERE id=" + id);

                status = true;
                MessageBox.Show("Data berhasil dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal Hapus Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }

        // ✅ Method untuk mencari equipment berdasarkan nama
        public List<Equipment> SearchEquipment(string keyword)
        {
            List<Equipment> equipmentList = new List<Equipment>();
            try
            {
                koneksi.OpenConnection();
                var result = koneksi.reader("SELECT * FROM Equipment WHERE name LIKE '%" + keyword + "%'");

                while (result.Read())
                {
                    Equipment equipment = new Equipment(
                        result.GetInt32("id"),
                        result.GetString("name"),
                        result.GetString("category"),
                        result.GetString("brand"),
                        result.GetDecimal("rental_price"),
                        result.GetInt32("stock"),
                        result.GetString("description"),
                        result.GetString("image_path"),
                        result.GetString("status")
                    );
                    equipmentList.Add(equipment);
                }
                result.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
         
            return equipmentList;
        }
        public bool IsEquipmentExists(string name)
        {
            try
            {
                koneksi.OpenConnection();
                var result = koneksi.reader("SELECT COUNT(*) FROM Equipment WHERE name = '" + name + "'");

                if (result.Read() && Convert.ToInt32(result[0]) > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }

            return false;
        }
    }
}
