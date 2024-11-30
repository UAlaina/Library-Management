using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using MLMS;

namespace MLMS2
{
    public partial class ReserveBook : Form
    {
        public ReserveBook()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainDashbboard c = new MainDashbboard();
            c.Show();
            this.Hide();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LibraryDb"].ConnectionString;

            try
            {
                string searchBy = searchByComboBox.SelectedItem?.ToString();
                string searchQuery = searchTextBox.Text.Trim();
                List<string> conditions = new List<string>();

                // Build search conditions based on user input
                if (!string.IsNullOrWhiteSpace(searchQuery))
                {
                    switch (searchBy)
                    {
                        case "By Book Name":
                            conditions.Add("Title LIKE '%' + @SearchQuery + '%'");
                            break;
                        case "By Author":
                            conditions.Add("Author LIKE '%' + @SearchQuery + '%'");
                            break;
                        case "By ISBN":
                            conditions.Add("ISBN = @SearchQuery");
                            break;
                        case "By Published Date":
                            conditions.Add("PublishedDate = @SearchQuery");
                            break;
                    }
                }

                // Construct the query to fetch book data
                string query = $@"
            SELECT 
                BookID, 
                Title, 
                ISBN,
                Author,
                YearPublished, 
                Edition,
                Description,
                Availability
            FROM Book
            WHERE {(conditions.Count > 0 ? string.Join(" AND ", conditions) : "1=1")}";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add search query parameter
                    if (!string.IsNullOrWhiteSpace(searchQuery))
                        cmd.Parameters.AddWithValue("@SearchQuery", searchQuery);

                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind the data to the DataGridView
                    dataGridViewBooks.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reserveBookButton_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LibraryDb"].ConnectionString;

            try
            {
                // Retrieve the logged-in user's MemberID
                int loggedInMemberId = GetLoggedInMemberID(); // Implement this method to return the current MemberID.

                // Ensure a book is selected in the DataGridView
                if (dataGridViewBooks.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a book to reserve.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the BookID from the selected row
                int selectedBookId = Convert.ToInt32(dataGridViewBooks.SelectedRows[0].Cells["BookId"].Value);

                string status = "Reserved";

                // Insert reservation into the database
                string query = @"INSERT INTO ReserveBooks (BookId, MemberId, Status)
                         VALUES (@BookId, @MemberId, @Status)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookId", selectedBookId);
                    cmd.Parameters.AddWithValue("@MemberId", loggedInMemberId);
                    cmd.Parameters.AddWithValue("@Status", status);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Reservation added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Optionally refresh the grid view
                        LoadReservations();
                    }
                    else
                    {
                        MessageBox.Show("Error while adding the reservation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetLoggedInMemberID()
        {
            return UserSession.MemberID;
        }

        private void LoadReservations()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LibraryDb"].ConnectionString;

            try
            {
                string query = @"
                SELECT R.ReserveID, B.Title, M.FullName, R.ReserveDate, R.Status
                FROM ReserveBooks R
                INNER JOIN Book B ON R.BookId = B.BookId
                INNER JOIN Member M ON R.MemberId = M.MemberId";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewBooks.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
