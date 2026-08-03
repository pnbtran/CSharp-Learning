# 020 QUẢN LÝ SÁCH 

## Tóm tắt 
- Thiết lập class có nhiều thuộc tính (mô tả sách)

- Viết hàm `constructor` nhận nhiều tham số

- Thêm phương thức cho đối tượng để tự hiển thị thông tin

- Tạo nhiều `object` cho đối tượng `book`

- Chọn kiểu dữ liệu `decimail` cho tham số giá 

## Luồng xử lý dữ liệu
- Ý tưởng giải quyết chính: 

```txt
Người dùng
↓
Console.ReadLine()
↓
Input()
↓
Constructor
↓
Book Object
↓
Book[]
↓
foreach
↓
Show()
↓
Console.WriteLine()
```

## Lưu ý
- `{Price:N0}` định dạng số có dấy phân cách hang nghìn, dùng cho số tiền hoặc số lớn. 

## Lỗi "vô tri" đã phát giác
### Property tự gọi chính nó (chịu, không ai cứu nổi ☹️)
- Ban đầu: 
```csharp
public decimal Price
{
    get
    {
        return Price;
    }

    set
    {
        Price = value;
    }
}
```
- Khi nhập giá, thông báo lỗi hiện ra =(( 
```txt
    StackOverflowException
```
- Nguyên nhân: 
>   get -> return Price -> get -> return Price -> ... 
>   set -> Price = value -> set -> Price = value
>   **=> vòng lặp VÔ HẠN, không hồi kết**  

- Cách khắc phục
```csharp
private decimal _price;

public decimal Price
{
    get
    {
        return _price;
    }

    set
    {
        if (value >= 0)
        {
            _price = value;
        }
    }
}
```
- Giả sửa `_price` là một hộp 
```txt
     Property

      Price
        │
   ┌────┴────┐
   │         │
 get       set
   │         │
   └────┬────┘
        │
     _price
```
Khi đó **property** chính là cánh cửa vào, dữ liệu thật nằm trong biến `_price` 

________________________________
**Thong tin nhap kiem thu**

```txt
ID: 978640
Ten sach: Ruoi trau
Nha xuat ban: Hong Duc
Tac gia: Ethel L. Voynich
Nam xuat ban: 2019
Gia: 128000
So trang: 507

ID: 978604
Ten sach: Nuoc Nga hoi sinh - Suc manh trong mot trat tu toan cau moi
Nha xuat ban: Chinh tri Quoc gia Su that
Tac gia: Kathryn E. Stoner
Nam xuat ban: 2022
Gia: 263000
So trang: 510

[978640] - Ruoi trau, NXB Hong Duc, Ethel L. Voynich, 2019, giá 128,000 VND, 507 trang
[978604] - Nuoc Nga hoi sinh - Suc manh trong mot trat tu toan cau moi, NXB Chinh tri Quoc gia Su that, Kathryn E. Stroner, 2022, giá 263,000 VND, 510 trang
```