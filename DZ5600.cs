using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public decimal Balance { get; set; }

        public User(string name, string surname, int age, decimal balance)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"{Name} {Surname}, Age: {Age}, Balance: {Balance:C}";
        }
    }

    public partial class Form1 : Form
    {
        private List<User> users = new List<User>();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string name = Name.Text;
                string surname = Surname.Text;
                int age = int.Parse(Age.Text);
                decimal balance = decimal.Parse(Balance.Text);

                User user = new User(name, surname, age, balance);
                users.Add(user);

                UpdateUserList();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating user: " + ex.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                users.RemoveAt(listBox1.SelectedIndex);
                UpdateUserList();
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            string searchQuery = Find.Text.ToLower();
            var filteredUsers = users.Where(user => user.Name.ToLower().Contains(searchQuery) || user.Surname.ToLower().Contains(searchQuery)).ToList();
            listBox1.Items.Clear();
            foreach (var user in filteredUsers)
            {
                listBox1.Items.Add(user);
            }
        }

        private void UpdateUserList()
        {
            listBox1.Items.Clear();
            foreach (var user in users)
            {
                listBox1.Items.Add(user);
            }
        }

        private void ClearInputFields()
        {
            Name.Clear();
            Surname.Clear();
            Age.Clear();
            Balance.Clear();
        }
    }
}