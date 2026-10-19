using System;
using System.Collections.Generic;

namespace SistemPerpustakaan
{
    // ===================== KELAS INDUK =====================
    public class Item
    {
        public string Judul { get; set; }
        public int Tahun { get; set; }

        public Item(string judul, int tahun)
        {
            Judul = judul;
            Tahun = tahun;
        }

        public virtual string Deskripsi()
        {
            return "Item: " + Judul + " (" + Tahun + ")";
        }

        public void InfoItem()
        {
            Console.WriteLine("Judul : " + Judul);
            Console.WriteLine("Tahun : " + Tahun);
        }
    }

    // ===================== BUKU & TURUNANNYA =====================
    public class Buku : Item
    {
        public string Penulis { get; set; }

        public Buku(string judul, int tahun, string penulis) : base(judul, tahun)
        {
            Penulis = penulis;
        }

        public void CekPenulis()
        {
            Console.WriteLine("Penulis buku '" + Judul + "' adalah " + Penulis);
        }

        public override string Deskripsi()
        {
            return "Buku: " + Judul + " (" + Tahun + ") karya " + Penulis;
        }
    }

    public class Novel : Buku
    {
        public Novel(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

        public void BacaSinopsis()
        {
            Console.WriteLine("Sinopsis novel '" + Judul + "': kisah fiksi panjang yang ditulis oleh " + Penulis + ".");
        }

        public override string Deskripsi()
        {
            return "Novel: " + Judul + " (" + Tahun + ") karya " + Penulis;
        }
    }

    public class Komik : Buku
    {
        public Komik(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

        public void TampilkanIlustrasi()
        {
            Console.WriteLine("Menampilkan ilustrasi gambar dari komik '" + Judul + "'.");
        }

        public override string Deskripsi()
        {
            return "Komik: " + Judul + " (" + Tahun + ") karya " + Penulis;
        }
    }

    // ===================== MAJALAH & TURUNANNYA =====================
    public class Majalah : Item
    {
        public int Edisi { get; set; }

        public Majalah(string judul, int tahun, int edisi) : base(judul, tahun)
        {
            Edisi = edisi;
        }

        public void InfoEdisi()
        {
            Console.WriteLine("Majalah '" + Judul + "' edisi ke-" + Edisi);
        }

        public override string Deskripsi()
        {
            return "Majalah: " + Judul + " (" + Tahun + ") edisi " + Edisi;
        }
    }

    public class MajalahAnak : Majalah
    {
        public MajalahAnak(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

        public void KategoriAnak()
        {
            Console.WriteLine("Kategori: majalah untuk anak-anak (cerita, dongeng, dan permainan).");
        }

        public override string Deskripsi()
        {
            return "Majalah Anak: " + Judul + " (" + Tahun + ") edisi " + Edisi;
        }
    }

    public class MajalahTeknologi : Majalah
    {
        public MajalahTeknologi(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

        public void TopikTeknologi()
        {
            Console.WriteLine("Topik majalah '" + Judul + "': gadget, software, dan perkembangan teknologi terbaru.");
        }

        public override string Deskripsi()
        {
            return "Majalah Teknologi: " + Judul + " (" + Tahun + ") edisi " + Edisi;
        }
    }

    // ===================== PERPUSTAKAAN =====================
    public class Perpustakaan
    {
        private List<Item> daftarItem = new List<Item>();

        public void TambahItem(Item item)
        {
            daftarItem.Add(item);
            Console.WriteLine("Item '" + item.Judul + "' berhasil ditambahkan.");
        }

        public void DaftarItem()
        {
            Console.WriteLine("=== DAFTAR ITEM PERPUSTAKAAN ===");
            if (daftarItem.Count == 0)
            {
                Console.WriteLine("(Perpustakaan masih kosong)");
                return;
            }
            int no = 1;
            foreach (Item item in daftarItem)
            {
                Console.WriteLine(no + ". " + item.Deskripsi());
                no++;
            }
        }
    }

    // ===================== PROGRAM UTAMA =====================
    class Program
    {
        static void Main(string[] args)
        {
            Perpustakaan perpus = new Perpustakaan();

            Novel novel = new Novel("Laskar Pelangi", 2005, "Andrea Hirata");
            Komik komik = new Komik("Doraemon Vol. 1", 1990, "Fujiko F. Fujio");
            MajalahAnak majalahAnak = new MajalahAnak("Bobo", 2023, 15);
            MajalahTeknologi majalahTek = new MajalahTeknologi("Tech Today", 2024, 8);
            Majalah majalah = new Majalah("Majalah Umum", 2022, 3);

            Console.WriteLine("--- Menambahkan item ---");
            perpus.TambahItem(novel);
            perpus.TambahItem(komik);
            perpus.TambahItem(majalahAnak);
            perpus.TambahItem(majalahTek);
            perpus.TambahItem(majalah);

            Console.WriteLine();
            perpus.DaftarItem();

            Console.WriteLine();
            Console.WriteLine("--- Demonstrasi Polymorphism ---");
            Item[] koleksi = { novel, komik, majalahAnak, majalahTek, majalah };
            foreach (Item it in koleksi)
            {
                Console.WriteLine(it.Deskripsi());
            }

            Console.WriteLine();
            Console.WriteLine("--- Method khusus tiap kelas ---");
            novel.CekPenulis();
            novel.BacaSinopsis();
            komik.TampilkanIlustrasi();
            majalahAnak.InfoEdisi();
            majalahAnak.KategoriAnak();
            majalahTek.TopikTeknologi();

            Console.ReadKey();
        }
    }
}