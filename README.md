# Payment System backend
 
<a href="https://github.com/fatmakurtulus/Payment-System-frontend" target="_blank">frontend</a>


## Proje Açıklaması

Bir sitede yöneticisiniz. Sitenizde yer alan dairelerin aidat ve ortak kullanım elektrik, su ve doğalgaz
faturalarının yönetimini bir sistem üzerinden yapacaksınız.
İki tip kullanıcınız var.

### 1-Admin/Yönetici

- Daire bilgilerini girebilir.
- İkamet eden kullanıcı bilgilerini girer.
- Daire başına ödenmesi gereken aidat ve fatura bilgilerini girer(Aylık olarak). Toplu veya tek
tek atama yapılabilir.
- Gelen ödeme bilgilerini görür.
- Gelen mesajları görür.
- Mesajların okunmuş/okunmamış/yeni mesaj olduğu anlaşılmalı.
- Aylık olarak borç-alacak listesini görür.
- Kişileri listeler, düzenler, siler.
- Daire/konut bilgilerini listeler, düzenler siler.

### 2-Kullanıcı
- Kendisine atanan fatura ve aidat bilgilerini görür.
- Sadece kredi kartı ile ödeme yapabilir.
- Yöneticiye mesaj gönderebilir.
- Mesajların okunmuş/okunmamış/yeni mesaj olduğu anlaşılmalı.
- Yaptığı ödemelerini görür.

Daire/Konut bilgilerinde
- Hangi blokda
- Durumu (Dolu-boş)
- Tipi (2+1 vb.)
- Bulunduğu kat
- Daire numarası
- Daire sahibi veya kiracı

Kullanıcı bilgilerinde
- Ad-soyad
- TCNo
- E-Mail
- Telefon
- Araç bilgisi(varsa plaka no)

Sistem kullanılmaya başladığında ilk olarak
1. Yönetici daire bilgilerini girer.
2. Kullanıcı bilgilerini girer.Giriş yapması için otomatik olarak bir şifre oluşturulur.
3. Kullanıcıları dairelere atar
4. Ay bazlı olarak aidat bilgilerini girer.
5. Ay bazlı olarak fatura bilgilerini girer

Arayüz dışında kullanıcıların kredi kartı ile ödeme yapabilmesi için ayrı bir servis yazılacaktır.
Bu servisde sistemde ki her bir kullanıcı için banka bilgileri(bakiye, kredi kartı no vb.) kontrol edilerek
ödeme yapılması sağlanır.
Ödeme sadece kredi kartı ile yapılabilir.

### Projede kullanılacaklar:

1. Web projesi backend için .Net Core, frontend için React.js kullanın.
2. Sistemin yönetimi/database için MS SQL Server kullanın.
3. Kredi kartı servisi için. Veriler mongodb de tutulacak. Servis .Net WebApi olarak yazılacaktır.
4. Mümkün olduğu kadar derslerde işlenen konular projeye entegre edilmelidir
