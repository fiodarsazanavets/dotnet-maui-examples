namespace MauiMvuExample;
public class MainPage : View
{

	[State]
	readonly TaxiRide taxi = new();

	[Body]
	View body()
		=> new VStack {
				new Text(()=> $"({taxi.RidesCount}) rides taken:{taxi.Rides}")
					.Frame(width:300)
					.LineBreakMode(LineBreakMode.CharacterWrap),

				new Button("Call a taxi 🚕", ()=>{
					taxi.RidesCount++;
				})
					.Frame(height:44)
					.Margin(8)
					.Color(Colors.White)
					.Background(Colors.Green)
				.RoundedBorder(color:Colors.Blue)
				.Shadow(Colors.Grey,4,2,2),
		};

	public class TaxiRide : BindingObject
	{
		public int RidesCount
		{
			get => GetProperty<int>();
			set => SetProperty(value);
		}

		public string Rides => "🚕".Repeat(RidesCount);
	}
}


