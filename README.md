# RentACar
ASP.NET Core MVC Rent a Car

Proje videosu : https://www.youtube.com/watch?v=FkVY_jAlHd0 video üzerinden inceleyebilirsiniz.


yazılım alanında 2. projemdir. Sistemde 2 adet background service çalışmaktadır bu servislerin bir tanesi günde 1 kere çalışarak araç kiralayan kişiye kiralama tarihi bir günden az kaldı ise hatırlatma maili gönderecektir.
Diğer bir servis ise yarım saat aralıklarla çalışarak kiradan dönen araç var mı yok mu kontrol sağlar ve araç var ise kiralama durumunu pasif yaparak diğer kullanıcının
kiralama işlemi yapabilmesine olanak tanır.

Sisteme iyzico ile ödeme entegrasonu eklendi ve kredi kartı bilgilerini girerek araç kiralama işlemi yapılabiliyor. Aynı şekilde müşteriden gelen iptal talepleri doğrultusunda admin onayına gönderilen iade talepleri onaylandığı taktirde para çekilen kart üzerinden iade işlemi yapılmaktadır.
