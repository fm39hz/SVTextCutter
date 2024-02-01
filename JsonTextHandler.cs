using Newtonsoft.Json;
using SVTextCutter.Format;

namespace SVTextCutter.Worker;

public static class JsonTextHandler
{
	private static string FileHandling(string fileName)
	{
		return "{\"header\":{\"compressed\":true,\"formatVersion\":5,\"hidef\":false,\"target\":\"i\"},\"readers\":[{\"type\":\"Microsoft.Xna.Framework.Content.DictionaryReader`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]\",\"version\":0},{\"type\":\"Microsoft.Xna.Framework.Content.StringReader\",\"version\":0}],\"content\":{\"abigail_videogames\":\"Urghh... Em vẫn không qua được màn đầu tiên trò 'Hành trình của Vua Thảo nguyên'!$u\",\"alex_lift_weights\":\"Unghh... Không nói chuyện được.\",\"caroline_exercise\":\"Đừng nhìn! Người cô nhễ nhại hết rồi.$s\",\"demetrius_dance\":\"%Demetrius đang bận.\",\"demetrius_read\":\"Chúng ta bị cách ly khỏi thế giới bên ngoài ở Thung lũng Stardew này. Có lẽ đó cũng là một điều tốt.\",\"emily_exercise\":\"Tập thể dục có thể rất vui đấy!\",\"haley_photo\":\"%Haley đang quá tập trung vào cái máy ảnh để chú ý đến bạn.\",\"harvey_examine_left\":\"Giờ giữ nguyên tư thế nhé... Hít một hơi thật sâu nào.$u\",\"harvey_radio\":\"%Harvey trông có vẻ đang rất bận.\",\"jodi_exercise\":\"Ungh... Hít vào.... Ungh.... Thở ra.$4\",\"marnie_exercise\":\"%Marnie cười với bạn qua một làn sương mồ hôi.\",\"penny_wave_left\":\"Thị trấn này rất an toàn, nhưng mình vẫn luôn đưa lũ trẻ về tận nhà.\",\"robin_dance\":\"%Robin đang bận.\",\"robin_exercise\":\"Tay cô thì khỏe rồi... *thở hổn hển*... nhưng chân phải tập thêm... *thở dốc*\",\"sam_gameboy\":\"Một giây thôi... tôi phải chơi nốt bàn này đã.$7\",\"sam_guitar\":\"%Sam đang bận tập ghi-ta.\",\"sam_pool\":\"$c .5#Hừm... Nếu cho bóng cái xoáy một chút, có thể mình sẽ...$7#$e#*Thở dài*... Tôi không giỏi trò này lắm.$s\",\"sam_skateboarding\":\"%Sam đang cố thực hiện một cú lật ván.\",\"sam_work\":\"%Sam đang rất vội... tốt hơn là không gây rắc rối cho cậu ta.\",\"shane_work\":\"%Shane đang làm việc chăm chỉ. Anh ta dường như không có hứng tán chuyện.\",\"vincent_read_right\":\"Cô giáo nói cháu phải đọc hết quyển sách này rồi mới được đi chơi.$s\"}}";
	}
	public static void StringCutting(string inputValue)
	{
		var _defaultText = JsonConvert.DeserializeObject<DefaultTextFormat>(FileHandling(inputValue));
		Console.WriteLine(JsonConvert.SerializeObject(_defaultText?.Content));
	}
}