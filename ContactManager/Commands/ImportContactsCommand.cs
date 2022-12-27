using ContactManager.Exceptions;
using ContactManager.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContactManager.Commands
{
    public class ImportContactsCommand : CommandBase
    {
        private readonly OpenFileDialog _openFileDialog;
        private readonly ContactsBook _contactsBook;
        public ImportContactsCommand(ContactsBook contactsBook)
        {
            _contactsBook = contactsBook;
            _openFileDialog = new OpenFileDialog();
            _openFileDialog.FileName = "Document"; // Default file name
            _openFileDialog.DefaultExt = ".txt"; // Default file extension
            _openFileDialog.Filter = "(.json)|*.json";
        }
        public override void Execute(object? parameter)
        {
            bool? result = _openFileDialog.ShowDialog();

            if (result == true)
            {
                string filePath = _openFileDialog.FileName;
                try
                {
                    _contactsBook.MergeContacts(filePath);
                } catch(Exception ex) { 
                    string exceptionMessage = ex.Message;

                    if (ex is RequiredPropertiesNullException)
                    {
                        MessageBox.Show(exceptionMessage);
                    }
                    else if(ex is PropertiesInContactsListAreEqualException)
                    {
                        MessageBox.Show(exceptionMessage);
                    }
                    else
                    {
                        MessageBox.Show($"Provided file is not in right structure. File path:{filePath}");
                    }
                }
            }
        }
    }
}
