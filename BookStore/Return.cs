﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BookStore
{
    public partial class Return : Form
    {
        public Return()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            SerializeDeserializeFile serializer = SerializeDeserializeFile.GetInstance();
            List<Customer> cList = new List<Customer>();
            List<Book> bList = new List<Book>();
            List<BorrowedBooks> borrow = new List<BorrowedBooks>();

            cList.Add(new Customer(3, "Justin", "123"));
            bList.Add(new Book("Test", "Test", "Test", 20.00));
            BookStore bStore = new BookStore(1, 3, "Son of a bitch");

            BookStoreInterface store = new BookStoreInterface(bList, bStore, cList, borrow);

            serializer.SerializeObjects(store);
        }
    }
}
