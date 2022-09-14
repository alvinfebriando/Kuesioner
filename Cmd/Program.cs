using Kuesioner.Application;
using Kuesioner.Application.DocumentPlanning;
using Kuesioner.Application.MicroPlanning;
using Kuesioner.Application.Realization;
using Kuesioner.Infrastructure;

var weights = new[]
{
    Data.Weight["mostly1"],
    Data.Weight["mostly1"],
    Data.Weight["mostly3"],
    Data.Weight["mostly3"],
    Data.Weight["mostly4"],
    Data.Weight["mostly5"]
};
const string lecturer = "pak alvin";
const int respondentCount = 100;
const int numberOfQuestion = 6;

var score = Util.GenerateScore(numberOfQuestion, respondentCount, weights);
var answers = Util.Process(score, Data.Questions);

var documentPlanning = new DocumentPlanning();
var dPlan = documentPlanning.CreateDPlan(lecturer, respondentCount, answers);

var microPlanning = new MicroPlanning(dPlan);
var mPlan = microPlanning.CreateMPlan();

var realization = new Realization(mPlan);
realization.AddFormatter();
var paragraph = realization.ConvertToSentence();

Console.WriteLine(string.Join(". ", paragraph));