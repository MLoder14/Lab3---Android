using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab3
{
    [Activity(Label = "Lab3", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        QuoteBank quoteCollection;
        TextView quotationTextView;
        TextView scoreTextView;

        EditText authorName;

        int score = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            // Create the quote collection and display the current quote
            quoteCollection = new QuoteBank();
            quoteCollection.LoadQuotes();
            quoteCollection.GetNextQuote();

            quotationTextView = FindViewById<TextView>(Resource.Id.quoteTextView);
            quotationTextView.Text = quoteCollection.CurrentQuote.Quotation;

            scoreTextView = FindViewById<TextView>(Resource.Id.scoreTextView);
            scoreTextView.Text = score.ToString();

            authorName = FindViewById<EditText>(Resource.Id.authorNameBox);

            

            // Display another quote when the "Next Quote" button is tapped
            var nextButton = FindViewById<Button>(Resource.Id.nextButton);
            nextButton.Click += delegate
            {
                quoteCollection.GetNextQuote();
                quotationTextView.Text = quoteCollection.CurrentQuote.Quotation;
            };

            var enterButton = FindViewById<Button>(Resource.Id.enterButton);
            enterButton.Click += (object sender, System.EventArgs e) =>
            {
                //string author = authorName.ToString();

                if (authorName.Text == quoteCollection.CurrentQuote.Person) //author matches what the user input )
                {
                    //increase our score
                    ++score;
                    //write to the score box
                    scoreTextView.Text = score.ToString();
                    //say it was right
                    authorName.Text = "You're right, it was :" + quoteCollection.CurrentQuote.Person;
                }
                else // (author doesnt match) maybe just an else not an else/if
                {
                    //decrease score
                    --score;
                    //write to the score box
                    scoreTextView.Text = score.ToString();
                    //say it was wrong
                    authorName.Text = "You're wrong, it was :" + quoteCollection.CurrentQuote.Person; //quoteCollection.CurrentQuote.Person;
                }

                //authorName.Text = Resources.GetString(Resource.String.authorTextView, author);

            };
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {

            base.OnSaveInstanceState(outState);
        }

    }
}

