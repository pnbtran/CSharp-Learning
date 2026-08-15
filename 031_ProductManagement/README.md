# 031 HỆ THỐNG QUẢN LÍ ĐƠN HÀNG 

## Tóm tắt
- Xây dựng các class: `Product, Customer, Order, OrderItem` có khả năng tương tác 
    - `Product` - Sản phẩm: mã, tên, giá bán

    - `Customer` - Khách hàng: mã, tên

    - `OrderItem` - Dòng hàng: sản phẩm nào, số lượng ra sao, thành tiền

    - `Order` - Đơn hàng: của KH nào? những mặt hàng nào?, tổng thành tiền

- Xây dựng mô hình "một đơn - nhiều dòng hàng" bằng `List<OrderItem>`

- Cho object tự tính toán (tổng) qua property tính toán

- Phân biệt 2 quan hệ: chứa (has - a) và kế thừa (is - a) 

- Dùng LINQ để thống kê doanh thu, tìm đơn max, lọc đơn theo khách

- OOP + Collection + LINQ - tương tác bằng cách nào? 

## Thuật toán
- [1] Xây dựng class `Product` và `Customer` 
    - Dùng `decimal` cho giá tiền, dùng `double` cộng `0.1 + 0.2 = 0.3000000000004` là banh xác (lỗi dấu chấm động kinh điển). 

- [2] Xây dựng class OrderItem với phương thức tính tiền: TT = ĐG x SL 
    - `OrderItem` chứa `product` theo quan hệ "has-a": dòng hàng có sản phẩm, không phải quan hệ kế thừa 

    - `Subtotal`: property tính toán, không lưu giá trị có sẵn. 

- [3] Xây dựng class `Order`
    - Một khách, có nhiều mặt hàng thì cần biểu diễn `List<OrderItem>` 

    - `Oder` chứa `List<OrderItem>` và `Total` dùng LINQ để `sum` gom nhiều thành tiền 

- [4] Xây dựng `Main` quản lí nhiều object 
    - Dùng LINQ để truy vấn đỡ phải viết hàng loạt vòng lặp 

- Mô hình quan hệ dữ liệu (Data model):
```txt
   Customer 1 ───< Order 1 ───< OrderItem >─── 1 Product
   (một khách nhiều đơn)  (một đơn nhiều dòng)   (mỗi dòng một sản phẩm)

```

## Lưu ý/ Tổng hợp
- Hệ thống quản lí = nhiều class (product, customer, order,...) + collections để quản lí và LINQ để truy vấn và thống kê. 

- Nguyên tắc SOLID: 
    - S → Single Responsibility - 1 class, 1 trách nhiệm chính 
    *Đừng ôm quá nhiều việc*. 

    - O → Open/Closed - dễ mở rộng, đóng để sửa đổi
    *Đừng sửa code cũ vì muốn thêm tính năng*. 

    - L → Liskov Substitution - Object của class con phải có thể thay thế object của class cha mà không làm chương trình hoạt động sai.
    *Con phải thay thế được cha*.

    - I → Interface Segregation - Không nên bắt một class phụ thuộc vào những method mà nó không cần.
    *Interface đừng quá béo phì*. 

    - D → Dependency Inversion - Module cấp cao không nên phụ thuộc trực tiếp vào module cấp thấp. Cả hai nên phụ thuộc vào abstraction (??) 
    *Đừng dính chặt implementation*.

- List       → vị trí [index]
  Dictionary → khóa → giá trị
  HashSet    → không trùng
  Queue      → FIFO
  Stack      → LIFO