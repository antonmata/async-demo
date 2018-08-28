using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;

namespace cs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            var demo = new AsyncDemo();
            demo.Run().GetAwaiter().GetResult();
        }
    }

    public class AsyncDemo
    {
        public async Task Run()
        {
            // var t = () => new Task(() => Console.WriteLine("Hello!"));
            // var sample1 = Task.Run(() => Console.WriteLine("Hello!"));

            // var x = await Sample1();
            // Console.WriteLine(x);
            await Ajax();
        }

        public async Task<int> Sample1()
        {
            return 12;
        }

        public async Task Ajax()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var res1 = await client.GetAsync("api/todo");
            var data1 = await res1.Content.ReadAsAsync<TodoItems>();

            Console.WriteLine(data1);

            var res2 = await client.PostAsJsonAsync<TodoItem>("api/todo", new TodoItem
            {
                Name = "Hello!",
                Completed = false
            });
            var data2 = await res2.Content.ReadAsAsync<TodoItem>();

            Console.WriteLine(data2);

            client.Dispose();
        }
    }

    public class TodoItems
    {
        public IEnumerable<TodoItem> Items { get; set; }

        public override string ToString()
        {
            return $"[ {string.Join(',', this.Items)} ]";
        }
    }

    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }

        public override string ToString()
        {
            return $"{{ id: {this.Id}, name: {this.Name}, completed: {this.Completed} }}";
        }
    }
}
