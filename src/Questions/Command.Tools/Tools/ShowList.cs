using System.Text;

namespace Command.Tools
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/8/23 12:06:29
    /// @source : 
    /// @des : 
    /// </summary>
    public class ShowList
    {
        public static string GetStr<T>(T[][] arr)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    builder.Append(arr[i][j]);
                    if (j < arr[i].Length - 1) builder.Append(',');
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}