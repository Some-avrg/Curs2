using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Sudoku
{
    [Serializable] public class Records
    {
        public Records()
        {
            _records = new List<Record>();
        }
        
        private List<Record> _records;

        public void AddRecord(string name, int time)
        {
            _records.Add(new Record(name, time));
        }

        public bool WriteRecordsInFile(string nameOfFile)
        {
            if (_records.First() == null) return false;
            FileStream file = new FileStream(nameOfFile, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);
            foreach (var rec in _records)
            {
               writer.WriteLine(rec._name);
               writer.WriteLine(rec._time);
            }
            writer.Close();
            return true;
        }

        public void ReadRecordsFromFile(string nameOfFile)
        {
            FileStream file;
            try
            {
                file = new FileStream(nameOfFile, FileMode.Open, FileAccess.Read);
            }
            catch (Exception)
            {
                MessageBox.Show("File does not exist");
                return;
            }

            StreamReader reader = new StreamReader(file);
            while (!reader.EndOfStream)
            {
                _records.Add(new Record(reader.ReadLine(), Int32.Parse(reader.ReadLine())));
            }
            
        }
    }

    internal class Record
    {
        internal string _name;
        internal int _time;

        public Record(string s, int i)
        {
            _name = s;
            _time = i;
        }
    }
}