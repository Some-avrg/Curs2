using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Sudoku
{
    [Serializable]
    public class Records
    {
        public Records()
        {
            ListOfRecords = new List<Record>();
        }

        public List<Record> ListOfRecords;

        public void AddRecord(string name, int time)
        {
            ListOfRecords.Add(new Record(name, time));
        }

        public bool WriteRecordsInFile(string nameOfFile)
        {
            if (ListOfRecords.First() == null) return false;
            FileStream file = new FileStream(nameOfFile, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);
            foreach (var rec in ListOfRecords)
            {
                writer.WriteLine(rec.Name);
                writer.WriteLine(rec.Time);
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
                ListOfRecords.Add(new Record(reader.ReadLine(), Int32.Parse(reader.ReadLine())));
            }
        }

    }

    public class Record
    {
        public string Name;
        public int Time;

        public Record(string s, int i)
        {
            Name = s;
            Time = i;
        }
    }


    public class BestTime : Comparer<Record>
    {
        public override int Compare(Record x, Record y)
        {
            if (x.Time.CompareTo(y.Time) != 0)
                return x.Time.CompareTo(y.Time);
            
            return 0;
        }
    }

}