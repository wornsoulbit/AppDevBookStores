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
        List<Customer> cList = new List<Customer>();
        List<BorrowedBooks> borrowList = new List<BorrowedBooks>();
        List<Book> bList = new List<Book>();
        BookStore bStore = new BookStore(1, 1, "Employee");

        int count = 0;

        SerializeDeserializeFile serializer = SerializeDeserializeFile.GetInstance();

        public Return()
        {
            InitializeComponent();
        }

        private void Return_Load(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            Book b = new Book(borrowList[count].SerialNum, borrowList[count].Title, borrowList[count].Author, borrowList[count].Price);

            bList.Add(b);
            borrowList.Remove(borrowList[count]);

            BookStoreInterface store = new BookStoreInterface(bList, bStore, cList, borrowList);

            serializer.SerializeObjects(store);

            count = 0;
            ShowDetails();
        }

        private void CatalogButton_Click(object sender, EventArgs e)
        {
            serializer.DeserializeObjbects();
            bList = serializer.GetBookList();
            ShowDetails();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            int checker = bList.Count();
            checker--;
            if (count < checker)
            {
                count++;
                ShowDetails();
            }
            else
            {
                count = 0;
                ShowDetails();
            }
        }
        private void ShowDetails()
        {
            NameTextbox.Text = bList[count].Title;
            AuthorTextbox.Text = bList[count].Author;
            SnTextbox.Text = bList[count].SerialNum;
        }

        private void ExitButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
