using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Speedtools.BL
{
    public class BlurbsLogic
    {
        public string filePath = string.Empty;
        public List<string> matrix = new List<string>();
        public string orgSelection;
        public string areaSelection;
        public string blurbSelection;
        public string firstLayerName;

        public void readBlurbsFromFile()
        {
            try
            {
                string csv = System.IO.File.ReadAllText(filePath);
                string[] rawMatrix = Regex.Split(csv, "\n(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                foreach (string line in rawMatrix)
                {
                    matrix.Add(line);
                }
                string[] headers = Regex.Split(matrix[0], ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                firstLayerName = headers[0];
                matrix.Remove(matrix[0]);
            }
            catch (Exception)
            {
                return;
            }
        }

        public List<string> uniqueOrg()
        {
            List<string> result = new List<string>();
            foreach (string line in matrix)
            {
                string[] lineArray = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                if (lineArray.Length < 4)
                {
                    continue;
                }
                result.Add(lineArray[0]);

            }
            return result.Distinct().ToList();
        }

        public List<string> uniqueArea()
        {
            List<string> result = new List<string>();
            foreach (string line in matrix)
            {
                string[] lineArray = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                if (lineArray.Length < 4)
                {
                    continue;
                }
                if (lineArray[0] == orgSelection)
                {
                    result.Add(lineArray[1]);
                }
            }
            return result.Distinct().ToList();
        }

        public List<string> blurbList()
        {
            List<string> result = new List<string>();
            foreach (string line in matrix)
            {
                string[] lineArray = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                if (lineArray.Length < 4)
                {
                    continue;
                }
                if (lineArray[0] == orgSelection && lineArray[1] == areaSelection)
                {
                    result.Add(lineArray[2]);
                }
            }
            return result;
        }

        public string textToCopy()
        {
            string result = string.Empty;
            foreach (string line in matrix)
            {
                string[] lineArray = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                if (lineArray.Length < 4)
                {
                    continue;
                }
                if (lineArray[0] == orgSelection && lineArray[1] == areaSelection && lineArray[2] == blurbSelection)
                {
                    result = lineArray[3].Trim();
                }
            }
            return result = result.Trim('"');
        }

    }
}
