namespace Maui.LMS.Pages;

public partial class StudentDetail : ContentPage
{
	public StudentDetail()
	{
		InitializeComponent();
	}
    
	private void DoneClick(object sender, EventArgs e)
	{
		// var context = BindingContext as StudentDetail;
		// string classification;
		// switch (context.ClassificationStr)
		// {
		// 	case "1":
		// 		classification = StudentClassification.Freshman;
		// 		break;
		// 	case "2":
		// 		classification = StudentClassification.Sophomore;
		// 		break;
		// 	case "3":
		// 		classification = StudentClassification.Junior;
		// 		break;
		// 	case "4":
  //               classification = StudentClassification.Senior;
  //               break;
		// }
		// StudentService.Current.Add(new Student { Name = context.Name, Classification = classification });
		Shell.Current.GoToAsync("//MainPage");
	}
}