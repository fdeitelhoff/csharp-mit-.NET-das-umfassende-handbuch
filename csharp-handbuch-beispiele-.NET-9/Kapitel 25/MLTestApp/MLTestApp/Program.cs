using MLTestApp;

var sampleData = new SentimentModel.ModelInput()
{
    Col0 = "McDonalds was horrible."
};

// Das Modell laden und die Ausgabe vorhersagen.
var result = SentimentModel.Predict(sampleData);

// Wenn die Vorhersage 1 ist, ist die Stimmung „positiv“; andernfalls ist die Stimmung „negativ“.
var sentiment = result.PredictedLabel == 1 ? "Positiv" : "Negativ";
Console.WriteLine($"Text: {sampleData.Col0}\nVorhersage: {sentiment}\nScore: {result.Score.Max()}");

Console.ReadLine();