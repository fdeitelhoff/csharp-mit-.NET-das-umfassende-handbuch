using Azure.AI.Vision.ImageAnalysis;
using Azure;

var endpoint = Environment.GetEnvironmentVariable("VISION_ENDPOINT") ?? "";
var key = Environment.GetEnvironmentVariable("VISION_KEY") ?? "";

// Den Image Analysis Client erzeugen.
ImageAnalysisClient client = new ImageAnalysisClient(
    new Uri(endpoint),
    new AzureKeyCredential(key));

// URL oder Buffer.
var imageURL = new Uri("https://aka.ms/azsdk/image-analysis/sample.jpg");
using FileStream stream = new FileStream("sample.jpg", FileMode.Open);
var imageData = BinaryData.FromStream(stream);

var visualFeatures =
    VisualFeatures.Caption |
    VisualFeatures.DenseCaptions |
    VisualFeatures.Objects |
    VisualFeatures.Read |
    VisualFeatures.Tags |
    VisualFeatures.People |
    VisualFeatures.SmartCrops;

ImageAnalysisOptions options = new ImageAnalysisOptions
{
    GenderNeutralCaption = true,
    Language = "en",
    SmartCropsAspectRatios = new float[] { 0.9F, 1.33F }
};

ImageAnalysisResult result = client.Analyze(
    imageURL,
    visualFeatures,
    options);

// Die Caption ausgeben
Console.WriteLine(" Caption:");
Console.WriteLine($"   '{result.Caption.Text}', Confidence {result.Caption.Confidence:F4}");

// Die Dense Caption ausgeben
Console.WriteLine(" Dense Captions:");
foreach (DenseCaption denseCaption in result.DenseCaptions.Values)
{
    Console.WriteLine($"   '{denseCaption.Text}', Confidence {denseCaption.Confidence:F4}, Bounding box {denseCaption.BoundingBox}");
}

// Die erkannten Objekte ausgeben
Console.WriteLine(" Objects:");
foreach (DetectedObject detectedObject in result.Objects.Values)
{
    Console.WriteLine($"   '{detectedObject.Tags.First().Name}', Bounding box {detectedObject.BoundingBox.ToString()}");
}

// Den Text (OCR) auf der Konsole ausgeben
Console.WriteLine(" Read:");
foreach (DetectedTextBlock block in result.Read.Blocks)
    foreach (DetectedTextLine line in block.Lines)
    {
        Console.WriteLine($"   Line: '{line.Text}', Bounding Polygon: [{string.Join(" ", line.BoundingPolygon)}]");
        foreach (DetectedTextWord word in line.Words)
        {
            Console.WriteLine($"     Word: '{word.Text}', Confidence {word.Confidence.ToString("#.####")}, Bounding Polygon: [{string.Join(" ", word.BoundingPolygon)}]");
        }
    }

// Die Tags ausgeben
Console.WriteLine(" Tags:");
foreach (DetectedTag tag in result.Tags.Values)
{
    Console.WriteLine($"   '{tag.Name}', Confidence {tag.Confidence:F4}");
}

// Die erkannten Personen auf der Konsole ausgeben
Console.WriteLine(" People:");
foreach (DetectedPerson person in result.People.Values)
{
    Console.WriteLine($"   Person: Bounding box {person.BoundingBox.ToString()}, Confidence {person.Confidence:F4}");
}

// Die Ergebnisse der Smart-Crops Analyse ausgeben
Console.WriteLine(" SmartCrops:");
foreach (CropRegion cropRegion in result.SmartCrops.Values)
{
    Console.WriteLine($"   Aspect ratio: {cropRegion.AspectRatio}, Bounding box: {cropRegion.BoundingBox}");
}

// Die Metadata ausgeben
Console.WriteLine(" Metadata:");
Console.WriteLine($"   Model: {result.ModelVersion}");
Console.WriteLine($"   Image width: {result.Metadata.Width}");
Console.WriteLine($"   Image hight: {result.Metadata.Height}");

Console.ReadLine();