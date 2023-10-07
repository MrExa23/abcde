using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{

    static void Main(string[] args)
    {
        int vyska = int.Parse(Console.ReadLine());
        string m = Console.ReadLine();
        int sirka = m.Length;
        Deska deska = new Deska(vyska, sirka);
        for (int i = 0; i < vyska; i++)
        {
            if (i > 0)
            {
                m = Console.ReadLine();
            }
            
            for (int j = 0; j < m.Length; j++)
            {
                deska.pozice[i,j].pismeno = m[j];
            }
        }
        
       
        deska.najdiPismenoA();




        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        
    }
}
class Policko
{
    public char pismeno { get; set; }
    public int id => (int)pismeno;
    public bool visited = false;
    public int x { get; set; }
    public int y { get; set; }


}
class Deska
{
    public Policko[,] pozice { get; set; }

    public Deska(int vyska, int sirka)
    {
        this.vyska = vyska;
        this.sirka = sirka;
        pozice = new Policko[vyska, sirka];

        for (int i = 0; i < vyska; i++)
        {
            for (int j = 0; j < sirka; j++)
            {
                pozice[i, j] = new Policko();
                pozice[i,j].x = i;
                pozice[i,j].y = j;
            }
        }
    }
    public int vyska { get; set; }
    public int sirka { get; set; }
    public List<Policko> najdiSousedy(int x, int y)
    {
        List<Policko>resault=new List<Policko>();
        if (x > 0)
        {
            if (pozice[x - 1, y].id == pozice[x, y].id + 1 && pozice[x - 1, y].visited == false)
            {
                resault.Add(pozice[x - 1, y]);
            }
        }
        if (x < vyska-1)
        {
            if (pozice[x + 1, y].id == pozice[x, y].id + 1 && pozice[x + 1, y].visited == false)
            {
                resault.Add(pozice[x + 1, y]);
            }
        }
        if (y > 0)
        {
            if (pozice[x, y - 1].id == pozice[x, y].id + 1 && pozice[x, y - 1].visited == false)
            {
                resault.Add(pozice[x, y - 1]);
            }
        }
        if (y < sirka-1)
        {
            if (pozice[x, y + 1].id == pozice[x, y].id + 1 && pozice[x, y + 1].visited == false)
            {
                resault.Add(pozice[x, y + 1]);
            }
        }
        return resault;
    }
    public void najdiPismenoA()
    {
        for (int i = 0; i < vyska; i++)
        {
            for (int j = 0; j < sirka; j++)
            {
                if (pozice[i, j].pismeno == 'a')
                {
                    List<Policko> listA = new List<Policko>();
                    listA.Add(pozice[i,j]);
                    hledejRadu(i,j,listA);
                }
            }
        }
    }
    public bool hledejRadu(int x, int y, List<Policko>list1)
    {
        List<Policko> soused = najdiSousedy(x, y);
        if(soused.Count > 0)
        {
            for (int i = 0; i < soused.Count; i++)
            {
                List<Policko> list2 = new List<Policko>(list1);
                list2.Add(soused[i]);
                soused[i].visited = true;
                if (list2.Count == 26)
                {
                    vysledek(list2);
                    return true;
                }
                if (hledejRadu(soused[i].x, soused[i].y, list2))
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void vysledek(List<Policko> list)
    {
        
        for (int i = 0; i < vyska; i++)
        {
            string s = "";
            for (int j = 0; j < sirka; j++)
            {
                if (list.Contains(pozice[i, j]))
                {
                    s = s + pozice[i, j].pismeno;
                }
                else
                {
                    s = s + "-";
                }
            }
            Console.WriteLine(s);
        }
    }
    
}
