using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;


class Program
{
    public static void Main(string[] args)
    {
        int cont = 0;
        int contador = 0;
        string caminho = "dado.json";
        if (File.Exists(caminho))
        {
            string json = File.ReadAllText(caminho);
            List<aux> midias = JsonConvert.DeserializeObject<List<aux>>(json);
            List<Midia> biblioteca = new List<Midia>();
            foreach (aux midia in midias)
            {
                Midia a = new Midia();
                a.setId(midia.id);
                a.setTitulo(midia.titulo);
                a.setGenero(midia.genero);
                a.setAutor(midia.autor);
                biblioteca.Add(a);
                cont++;
              contador++;
            }
            int i = 5;
            while (i != 0)
            {
                Console.WriteLine("====================================");
                Console.WriteLine("Digite: \n1)Listar.\n2)Adicionar.\n3)Editar.\n4)Apagar. \n0)Sair.");
                i = int.Parse(Console.ReadLine());
                switch (i)
                {
                    case (1):
                        Console.WriteLine("=========LISTAR=========");
                        foreach (Midia midia in biblioteca)
                        {
                            Console.WriteLine("Id: " + midia.getId());
                            Console.WriteLine("Titulo: " + midia.getTitulo());
                            Console.WriteLine("Genero: " + midia.getGenero());
                            Console.WriteLine("Autor: " + midia.getAutor());
                            Console.WriteLine("=======================");
                        }
                        break;
                    case (2):
                        Midia a = new Midia();
                        cont++;
                        Console.WriteLine("===========================CADASTRAR===========================");
                        Console.WriteLine("Nome do autor: ");
                        a.setAutor(Console.ReadLine());
                        Console.WriteLine("Nome da obra:");
                        a.setTitulo(Console.ReadLine());
                        Console.WriteLine("Qual genero: ");
                        a.setGenero(Console.ReadLine());
                        a.setId(cont);
                        biblioteca.Add(a);
                        break;
                    case (3):
                        Console.WriteLine("===========================ATUALIZAR===========================");
                        Console.WriteLine("Qual o id da obra que deseja atualizar?");
                        int identificador = int.Parse(Console.ReadLine());
                        for (int j = 0; j < biblioteca.Count; j++)
                        {
                            if (biblioteca[j].getId() == identificador)
                            {
                                Console.WriteLine("Nome do autor: ");
                                biblioteca[j].setAutor(Console.ReadLine());
                                Console.WriteLine("Nome da obra:");
                                biblioteca[j].setTitulo(Console.ReadLine());
                                Console.WriteLine("Qual genero: ");
                                biblioteca[j].setGenero(Console.ReadLine());
                            }
                        }
                        break;
                    case (4):
                        Console.WriteLine("===========================EXCLUIR===========================");
                        Console.WriteLine("Digite o id da midia.");
                        int ident = int.Parse(Console.ReadLine());
                        for (int j = 0; j < biblioteca.Count; j++)
                        {
                            if (biblioteca[j].getId() == ident)
                            {
                                biblioteca.RemoveAt(j);
                            }
                        }
                        break;
                }
            }
            for(int t = contador; t < biblioteca.Count; t++){
              aux b = new aux();
              b.autor = biblioteca[t].getAutor();
              b.genero = biblioteca[t].getGenero();
              b.id = biblioteca[t].getId();
              b.titulo = biblioteca[t].getTitulo();
              midias.Add(b);
            }
            string json2 = JsonConvert.SerializeObject(midias);
            File.WriteAllText(caminho, json2);
        }

    }
}

class aux
{
    public int id;
    public string titulo;
    public string genero;
    public string autor;
    public aux()
    {

    }
}