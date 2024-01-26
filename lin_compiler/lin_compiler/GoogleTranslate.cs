using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Text.RegularExpressions;
using LIN;
using System.Diagnostics;
namespace dr_lin
{
    public class GoogleTranslate
    {
        private static List<string> languages = new List<string>() 
        {
            "en",
            "es",
            "fr",
            "de",
            "pt",
            "ru",
            "zh",
            "ja",
            "ar",
            "ko",
            "hi",
            "bn",
            "id",
            "ms",
            "tr",
            "th",
            "vi",
            "nl",
            "sv"
        };
        private static HttpClient translateClient = new HttpClient()
        {
            BaseAddress = new Uri("https://clients5.google.com"),
        };
        private static Random rnd = new Random();
        private async static Task<string> Translate(string inp, string la)
        {
            HttpResponseMessage response = await translateClient.GetAsync("/translate_a/t?client=dict-chrome-ex&sl=" + "auto" + "&tl=" + la + "&q=" + inp);

            response.EnsureSuccessStatusCode();
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var stuff = JsonSerializer.Deserialize<List<List<string>>>(jsonResponse);
            jsonResponse = stuff[0][0];
            //Console.WriteLine($"{jsonResponse}\n");
            return jsonResponse;
        }
        public static async Task<string> TranslateLine(string inp, int depth = 5)
        {
            string o = "";
            string findTagString = @"(<CLT 1>.*?<CLT>)|(<CLT 9>.*?<CLT>)|(<CLT 69>.*?<CLT>)|(<.*?>)|(\\n)";
            Regex findTag = new Regex(findTagString);
            string[] og = findTag.Split(inp);
            List<string> good = new List<string>();
            List<string> translated = new List<string>();
            foreach (string tag in og)
            {
                if (!findTag.IsMatch(tag) && tag.Trim().Replace(" ", "").Length > 1)
                {
                    good.Add(tag.Trim());
                }
            }
            /*string newText = string.Join(";", good);
            for (int i = 0; i < depth; i++)
            {
                newText = await Translate(newText, languages[rnd.Next(languages.Count - 1)]);
            }
            newText = await Translate(newText, "en");
            translated = newText.Split(";").ToList();*/
            int t = 0;
            int CursorPos = Console.CursorLeft;
            foreach (string tag in good)
            {
                Console.CursorLeft = CursorPos;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("(" + t + "/" + good.Count + ")");
                Console.ForegroundColor = ConsoleColor.Gray;

                int CursorPos2 = Console.CursorLeft;
                string newText = tag;
                for (int i = 0; i < depth; i++)
                {
                    Console.CursorLeft = CursorPos2;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("(" + i + "/" + depth + ")");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    newText = await Translate(newText, languages[rnd.Next(languages.Count - 1)]);
                }
                newText = await Translate(newText, "en");
                //Console.WriteLine(newText);
                translated.Add(newText);
                t++;
            }
            o = inp;
            for (int i = 0; i < good.Count; i++)
            {
                if (i >= translated.Count)
                {
                    continue;
                }
                string n = translated[i];
                if (n.Length < 1)
                {
                    continue;
                }
                if (!char.IsUpper(good[i][0]))
                {
                    n = n.ToCharArray()[0].ToString().ToLower() + n.Substring(1);
                }
                o = o.Replace(good[i], n);
            }
            //Console.WriteLine(inp);
            //Console.WriteLine(o);
            //Console.WriteLine(string.Join("\n", og));
            return o;
        }
        private static void PrintProgress(int a, int aa, int b, int bb)
        {
            Console.CursorLeft = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("(" + a + "/" + aa + ")");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("(" + b + "/" + bb + ")");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void TranslateDirectory(string in_path, string out_path, Game game = Game.Danganronpa1)
        {
            Console.WriteLine("Translating files from " + in_path + " to " + out_path);
            string[] FilePathsIn = Directory.GetFiles(in_path);

            //System.IO.StreamWriter OutFileWriter = new System.IO.StreamWriter(out_file, false, Encoding.Unicode);

            int x = 0;
            foreach (string filePath in FilePathsIn)
            {
                if (!filePath.EndsWith(".lin"))
                    continue;
                //Console.WriteLine("Processing " + filePath);
                //OutFileWriter.WriteLine("# [" + filePath + "]");
                x++;
                try
                {
                    Script s = new Script(filePath, true, game);
                    if (s.ScriptData.Count < 1)
                    {
                        continue;
                    }
                    int textCount = 0;
                    foreach (ScriptEntry e in s.ScriptData)
                    {
                        if (e.Text == null)
                        {
                            continue;
                        }
                        if (e.Text.Length < 2)
                        {
                            continue;
                        }
                        textCount++;
                    }
                    if (textCount == 0)
                    {
                        continue;
                    }
                    int progress = 0;
                    PrintProgress(x, FilePathsIn.Length, progress, textCount);
                    foreach (ScriptEntry e in s.ScriptData)
                    {
                      
                        if (e.Text == null)
                        {
                            continue;
                        }
                        if (e.Text.Length < 2)
                        {
                            continue;
                        }
                        progress++;
                        int recursion = 5;
                        if (e.Text.Length > 140)
                        {
                            recursion = 3;
                        }
                        else if (e.Text.Length > 130)
                        {
                            recursion = 4;
                        }
                        else if (e.Text.Length > 90)
                        {
                            recursion = 5;
                        }
                        else if (e.Text.Length > 70)
                        {
                            recursion = 5;
                        }
                        else if (e.Text.Length > 50)
                        {
                            recursion = 6;
                        }
                        else if (e.Text.Length > 35)
                        {
                            recursion = 7;
                        }
                        else
                        {
                            recursion = 10;
                        }
                        var task = GoogleTranslate.TranslateLine(e.Text, recursion);
                        task.Wait();
                        e.Text = task.Result;
                        PrintProgress(x, FilePathsIn.Length, progress, textCount);
                    }
                    PrintProgress(x, FilePathsIn.Length, progress, textCount);
                    string new_path = filePath.Replace(in_path, out_path);
                    ScriptWrite.WriteCompiled(s, new_path, game);
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("CRITICAL ERROR OCCURED WHILE EXTRACTING THE FILE");
                    Console.WriteLine(e);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Finished!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

}
