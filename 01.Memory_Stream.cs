using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;                // 입출력에 관련된 기능을 사용하려면 추가

namespace CPPPP
{
    class Memory_Stream 
    {
        public static void Main()
        {
            byte[] shortBytes = BitConverter.GetBytes((short)32000);    // short형 값을 직렬화하여 byte형 배열에 저장
            byte[] intBytes = BitConverter.GetBytes(1652300);           // int형 값을 직혈화하여 byte형 배열에 저장

            MemoryStream ms = new MemoryStream();               // 메모리에 바이트 데이터를 순서대로 읽고 쓰는 작업을 수행하는 클래스다.
                                                                // MemoryStream은 Stream 추상 클래스를 상속받은 타입이다.
                                                                // Stream 타입은 일련의 바이트를 일관성 있게 다루는 공통 기반을 제공한다.
            ms.Write(shortBytes, 0, shortBytes.Length);         // 바이트 배열을 처음부터 배열의 길이만큼
            ms.Write(intBytes, 0, intBytes.Length);             // 메모리 스트림에 저장한다.

            ms.Position = 0;                                    // 메모리 스트림의 포인터는 현재 메모리 스트림의 끝부분을 가리키고 있다.
                                                                // 따라서 포인터가 제일 앞 부분을 가리키게 한다.

            byte[] outBytes = new byte[2];                      // 새롭게 크기 2인 바이트 배열을 생성
            ms.Read(outBytes, 0, 2);                            // 새롭게 만든 바이트 배열에 메모리 스트림에서 2만큼 메모리를 읽어서 저장한다.
            int shortResult = BitConverter.ToInt16(outBytes, 0);// 바이트 배열을 short형으로 역직렬화해서 저장
            Console.WriteLine(shortResult);                     // 출력 결과: 32000

                                                                // 현재 메모리 스트림은 2만큼 이동한 위치에 존재한다.
                                                                // 따라서 나머지 데이터를 바로 읽으므로 문제가 발생하지는 않는다.

            outBytes = new byte[4];                             // 기존 변수에 새롭게 크기 4인 바이트 배열을 생성 
            ms.Read(outBytes, 0, 4);                            // 바이트 배열에 메모리 스트림에서 4만큼 메모리를 읽어서 저장한다.
            int intRsult = BitConverter.ToInt32(outBytes, 0);   // 바이트 배열을 int형으로 역직렬화해서 저장
            Console.WriteLine(intRsult);                        // 출력 결과: 1652300
        }
    }
}