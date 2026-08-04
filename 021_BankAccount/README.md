# 021 XÂY DỰNG LỚP QUẢN LÍ BANK ACCOUNT 

## Tóm tắt
- Phân biệt `public` và `private` (quyền truy cập class). Lý do tại sao không nên sử dụng `public` cho tất cả đối tượng. 

- Hiểu được tính đóng gói (encapsulution).

- Viêt phương thức: gửi tiền (deposit), rút tiền (withdraw), kiểm tra tính hợp lệ (validation).

- Dùng property rút gọn `{get; private set;}` thay cho getter thủ công. 
 
## Thuật toán
- Sơ đồ luồng xử lý: 
    1. Tài khoản được tạp sẵn (số TK, chủ thẻ, số dư ban đầu)

    2. Người dùng nhập yêu cầu: Nạp/ Rút? 

    3. Nhập số tiền tương ứng

    4. Kiểm tra tính hợp lệ

    5. Thực hiện giao dịch

    6. Xuất thông báo cho KH

- Cấu trúc chương trình
```txt
Program
│
├── class BankAccount
│     ├── Deposit()
│     ├── Withdraw()
│     ├── GetBalance()
│     └── ...
│
├── ShowMenu()
├── InputMoney()
├── RunBank(BankAccount acc)
│
└── Main()
```

## Lưu ý
- Phân biệt `public` và `private`
    - `public` cho phép truy cập bất cứ đâu trong chương trình.

    - `private` chỉ cho phép truy cập chính bên trong `class`.

- Cách 1: 
```csharp
    private decimal balance;
``` 
- Cách 2: 
```csharp
    public decimal balance { get; private set; }
```
 --> **Cách 2** viết gọn và sạch hơn, cho phép đọc từ bên ngoài thông qua `acc.balance`, nhưng không cho phép sửa từ bên ngoài (do private set).
