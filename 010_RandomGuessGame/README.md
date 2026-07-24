# 010 GAME ĐOÁN SỐ NGẪU NHIÊN

## Nội dung 
[] Dùng lớp `ramdom` để tạo số ngẫu nhiên

[] Dùng vòng lặp `while` làm vòng lặp chính của trò chơi

[] Dùng `if - else` để gợi ý lớn hơn hoặc nhỏ hơn 

[] Dùng `continue` để bỏ qua lượt nhập sai

[] Thêm tính năng giới hạn số lần đoán

## Thuật toán
1. Tạo số bí mật và khai báo biến

2. Tạo vòng lặp chính của trò chơi

3. Thêm giới hạn số lần đoán

## Lưu ý
- `Next(a, b)` là khoảng `[a, b-1]`

- **Ý tưởng**: random số 1 lần cho cả trò chơi
```csharp
// SAI: tạo Random MỚI trong vòng lặp
for (int i = 0; i < 5; i++)
{
    Random r = new Random();
    Console.WriteLine(r.Next(1, 101)); // có thể ra 5 số GIỐNG HỆT nhau!
}

// ĐÚNG: tạo Random MỘT LẦN, dùng nhiều lần
Random random = new Random();
for (int i = 0; i < 5; i++)
    Console.WriteLine(random.Next(1, 101)); // 5 số khác nhau

```

## Bài tập khác
> Viết chương trình nhập vào hai số nguyên: số bí mật (secret) và số dự đoán (guess) từ bàn phím (mỗi số trên một dòng). So sánh số dự đoán với số bí mật và in ra một trong các kết quả sau:

'Cao hon' nếu guess > secret
'Thap hon' nếu guess < secret
'Chinh xac' nếu guess == secret
Lưu ý: Để tránh lỗi mã hóa, kết quả in ra không sử dụng dấu (viết không dấu).

Ví dụ:
Input:
42
42
Output:
Chinh xac

Input:
10
5
Output:
Thap hon

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        int secret = int.Parse(Console.ReadLine());
        int guess = int.Parse(Console.ReadLine());

        if (guess > secret)
        {
            Console.WriteLine("Cao hon");
        }
        else if (guess < secret)
        {
            Console.WriteLine("Thap hon");
        }
        else
        {
            Console.WriteLine("Chinh xac");
        }
    }
}
```