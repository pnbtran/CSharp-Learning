# 016 CỘNG HAI MA TRẬN 
## Tóm tắt
- Ma trận = mảng 2 chiều `int[,]`, mỗi ô định vị bằng `[hàng, cột]`; duyệt bằng vòng lặp lồng; cộng = cộng từng ô tương ứng. 
- Khai báo và khởi tạo mảng hai chiều `int[,]`.
- Truy cập phần tử bằng `[hàng, cột]`.
- Dùng `GetLength(0)/ GetLength(1)` để lấy số hàng số cột. 
- Duyệt ma trận bằng vòng lặp vòng. 
- Cộng hai ma trận cùng kích thước. 

## Cộng hai ma trận
- Logic: Kiểm tran cùng cỡ -> duyệt từng ô -> cộng ô tương đương -> lưu và trả kết quả

- Thuật toán: 

```csharp 
static void Main(string[] args)
{ 
    int[,] MatrixA = { { 2, 2, 4 }, { 5, 4, 7 }, { 9, 2, 8 } };
    int[,] MatrixB = { { 1, 1, 2 }, { 5, 6, 3 }, { 5, 7, 4 } };
    int[,] Result = new int[3, 3];

    int Row = MatrixA.GetLength(0);
    int Column = MatrixA.GetLength(1);

    for (int i = 0; i < Row; i++)
    {
        for (int j = 0; j < Column; j++)
        {
            Result[i, j] = MatrixA[i, j] + MatrixB[i, j];
        }
    }

    Console.WriteLine("Ket qua Tong hai ma tran: ");
    for (int i = 0; i < Row; i++)
    {
        for (int j =0; j < Column; j++)
        {
            Console.Write($"{Result[i, j],4}");
        }
        Console.WriteLine();
    }
```
- **Kết quả**: (mình thấy cách ghi này không đẹp và cũng không thông minh)
```txt
Kết quả Tong hai ma tran
    3    3   6
    10  10  10
    14   9  12
```

- **In kiểu toán học**. Mô hình ý tưởng bằng `for` và `if`
``` txt
                row = 0
────────────────────────────────────────────
| Matrix A |     | Matrix B |     | Result |

                row = 1
────────────────────────────────────────────
| Matrix A |  +  | Matrix B |  =  | Result |

                row = 2
────────────────────────────────────────────
| Matrix A |     | Matrix B |     | Result |
```

```txt
for
|
|__ Quyết định in hàng nào? 
|
|__if
    |
    |__Quyết định in dấu gì? 
    |
    |__Quyết định in ở đâu? 
```