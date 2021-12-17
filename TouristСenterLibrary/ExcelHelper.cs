using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using TouristСenterLibrary.Entity;


namespace tourCenter
{
    public class ExcelHelper : IDisposable
    {
        private Application _excel;
        private Workbook _workbook;
        private string _filePath;

        public ExcelHelper()
        {
            _excel = new Excel.Application();
        }
        public bool Open(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    _workbook = _excel.Workbooks.Open(filePath);
                }
                else
                {
                    _workbook = _excel.Workbooks.Add();
                    _filePath = filePath;
                    
                }

                return true;
            }
            catch (Exception ex) {/* MessageBox.Show(ex.Message);*/ }          
            return false;
        }
        public bool SetParticipant(List<Participant> participants)
        {
            try
            {
                for (int i = 0; i < participants.Count; i++)
                {
                    ((Excel.Worksheet)_excel.ActiveSheet).Cells[i + 1, "A"].Value = participants[i].Surname;
                    ((Excel.Worksheet)_excel.ActiveSheet).Cells[i + 1, "B"].Value = participants[i].Name;
                    if(participants[i].Middlename !=null)
                        ((Excel.Worksheet)_excel.ActiveSheet).Cells[i + 1, "C"].Value = participants[i].Middlename;
                    ((Excel.Worksheet)_excel.ActiveSheet).Cells[i + 1, "D"].Value = participants[i].ClientTelefonNumber;
                }
               
                return true;
            }
            catch (Exception ex) { /*MessageBox.Show(ex.Message); */}
            return false;

        }

        public void Dispose()
        {
            try
            {
                _workbook.Close();
            } 
            catch(Exception ex) { /*MessageBox.Show(ex.Message);*/ }
        }

        public void Save()
        {
            if (!string.IsNullOrEmpty(_filePath))
            {
                _workbook.SaveAs(_filePath);
                _filePath = null;
            }
            else
            {
                _workbook.Save();
            }
        }
    }
}
