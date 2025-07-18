🛍️ SkiNet E-commerce App (.NET Core & Angular)

Bu proje, Udemy'deki "Learn to build an e-commerce app with .NET Core and Angular" kursunun uygulanmasıdır. 
2. Kısmı Tamamladım:

🚀 Tamamlanan Bölüm

  - API Basics
  - CRUD işlemleri (Create, Read, Update, Delete) için Products endpoint'leri
  - Docker üzerinde SQL Server kurulumu ve konfigürasyonu
  - Postman üzerinden test senaryoları

⚙️ Kullanılan Teknolojiler

- .NET Core
- Entity Framework Core
- SQL Server (Docker container)
- Postman (API testleri için)
- Docker Desktop
- Visual Studio Code

🗄️ Veritabanı

- SQL Server Docker container kullanılarak kuruldu.
- Migration işlemleri tamamlandı.
- `skinet` isimli veritabanı oluşturuldu ve bağlandı.

💻 API Test

Postman kullanılarak ürün ekleme, listeleme, güncelleme ve silme işlemleri test edilmiştir.


Docker SQL Server Container

<img width="1778" height="968" alt="image" src="https://github.com/user-attachments/assets/b7ea743a-77eb-4671-99e0-e613f33f450b" />

Postman API Test

<img width="1752" height="828" alt="image" src="https://github.com/user-attachments/assets/76f8dbf7-7b4c-43fe-b85c-6e591e49e328" />

3. Kısmı Tamamladım:
   
Repository pattern yapısı kuruldu ve uygulandı.

Repository interface ve implementasyon class'ları oluşturuldu.

Repository method'ları yazıldı.

Controller'da repository kullanımı sağlandı.

Veritabanı için örnek (seed) ürün verileri eklendi.

Marka ve ürün tiplerini çekme endpoint'leri geliştirildi.

Ürünler için markaya göre filtreleme özelliği eklendi.

Ürünleri sıralama (sorting) özelliği eklendi.

⚙️ Yeni Eklenen Özellikler

Marka ve tip bilgilerini listeleme.

Ürünlerde sıralama ve filtreleme desteği.

Daha düzenli ve ölçeklenebilir veri erişim katmanı.


📂 Çalıştırma

```bash
# API'yi başlat
dotnet run
