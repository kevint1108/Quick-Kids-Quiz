using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System.Runtime.CompilerServices;

namespace Quick_Kids_Quiz
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private List<QuizQuestion> _questions = new();
        private int _currentQuestionIndex = 0;
        private int _score = 0;
        private bool _hasAnswered = false;
        private string _selectedAnswer = string.Empty;

        public QuizQuestion? CurrentQuestion { get; set; }
        public int CurrentQuestionNumber => _currentQuestionIndex + 1;
        public int Score => _score;

        public MainPage()
        {
            InitializeComponent();
            InitializeQuiz();
            BindingContext = this;
        }

        private void InitializeQuiz()
        {
            _questions = QuizQuestions.GetQuestions()
                .OrderBy(x => Guid.NewGuid())
                .Take(10)
                .ToList();

            _currentQuestionIndex = 0;
            _score = 0;
            _hasAnswered = false;

            LoadCurrentQuestion();
            ResetUI();
        }

        private void LoadCurrentQuestion()
        {
            if (_currentQuestionIndex < _questions.Count)
            {
                CurrentQuestion = _questions[_currentQuestionIndex];
                OnPropertyChanged(nameof(CurrentQuestion));
                OnPropertyChanged(nameof(CurrentQuestionNumber));
            }
        }

        private void ResetUI()
        {
            // Get references to UI elements
            var optionA = this.FindByName<Button>("OptionA");
            var optionB = this.FindByName<Button>("OptionB");
            var optionC = this.FindByName<Button>("OptionC");
            var optionD = this.FindByName<Button>("OptionD");
            var feedbackFrame = this.FindByName<Frame>("FeedbackFrame");
            var nextButton = this.FindByName<Button>("NextButton");
            var restartButton = this.FindByName<Button>("RestartButton");
            var gameOverFrame = this.FindByName<Frame>("GameOverFrame");

            // Reset button colors
            if (optionA != null) optionA.BackgroundColor = Colors.LightBlue;
            if (optionB != null) optionB.BackgroundColor = Colors.LightBlue;
            if (optionC != null) optionC.BackgroundColor = Colors.LightBlue;
            if (optionD != null) optionD.BackgroundColor = Colors.LightBlue;

            // Reset button states
            if (optionA != null) optionA.IsEnabled = true;
            if (optionB != null) optionB.IsEnabled = true;
            if (optionC != null) optionC.IsEnabled = true;
            if (optionD != null) optionD.IsEnabled = true;

            // Hide feedback and next button
            if (feedbackFrame != null) feedbackFrame.IsVisible = false;
            if (nextButton != null) nextButton.IsVisible = false;
            if (restartButton != null) restartButton.IsVisible = false;
            if (gameOverFrame != null) gameOverFrame.IsVisible = false;

            _hasAnswered = false;
            _selectedAnswer = string.Empty;
        }

        private async void OnAnswerSelected(object sender, EventArgs e)
        {
            // Prevent multiple answers
            if (_hasAnswered)
                return;

            if (sender is not Button button)
                return;

            // Get the selected answer (e.g., "A", "B", "C", or "D")
            _selectedAnswer = button.CommandParameter?.ToString() ?? string.Empty;

            _hasAnswered = true;

            // Disable all option buttons after answer selection
            var optionA = this.FindByName<Button>("OptionA");
            var optionB = this.FindByName<Button>("OptionB");
            var optionC = this.FindByName<Button>("OptionC");
            var optionD = this.FindByName<Button>("OptionD");

            optionA.IsEnabled = false;
            optionB.IsEnabled = false;
            optionC.IsEnabled = false;
            optionD.IsEnabled = false;

            // Check if selected answer is correct
            bool isCorrect = _selectedAnswer == CurrentQuestion!.CorrectAnswer;

            // Update score if correct
            if (isCorrect)
            {
                _score++;
                OnPropertyChanged(nameof(Score)); // notify UI about score change
            }

            // Highlight answers (simplified example)
            if (button != null)
            {
                button.BackgroundColor = isCorrect ? Colors.LightGreen : Colors.LightPink;
            }

            var correctButton = GetButtonByOption(CurrentQuestion.CorrectAnswer);
            if (correctButton != null && correctButton != button)
            {
                await Task.Delay(500);
                correctButton.BackgroundColor = Colors.LightGreen;
            }

            // Show feedback (simplified)
            var feedbackFrame = this.FindByName<Frame>("FeedbackFrame");
            var feedbackText = this.FindByName<Label>("FeedbackText");
            var feedbackIcon = this.FindByName<Label>("FeedbackIcon");

            if (feedbackFrame != null)
                feedbackFrame.IsVisible = true;

            if (isCorrect)
            {
                if (feedbackFrame != null) feedbackFrame.BackgroundColor = Colors.LightGreen;
                if (feedbackIcon != null) feedbackIcon.Text = "✅";
                if (feedbackText != null)
                {
                    feedbackText.Text = "Correct! Well done! 🎉";
                    feedbackText.TextColor = Colors.DarkGreen;
                }
            }
            else
            {
                if (feedbackFrame != null) feedbackFrame.BackgroundColor = Colors.LightPink;
                if (feedbackIcon != null) feedbackIcon.Text = "❌";
                if (feedbackText != null)
                {
                    feedbackText.Text = $"Not quite! {CurrentQuestion.Explanation}";
                    feedbackText.TextColor = Colors.DarkRed;
                }
            }

            // Show the Next button if there are more questions
            var nextButton = this.FindByName<Button>("NextButton");
            if (_currentQuestionIndex < _questions.Count - 1)
            {
                if (nextButton != null) nextButton.IsVisible = true;
            }
            else
            {
                // Or show game over after a delay
                await Task.Delay(2000);
                ShowGameOver();
            }
        }


        private async Task HighlightAnswers(bool isCorrect)
        {
            // Highlight selected answer
            Button? selectedButton = GetButtonByOption(_selectedAnswer);
            if (selectedButton != null)
            {
                selectedButton.BackgroundColor = isCorrect ?
                    Colors.LightGreen : // Light green for correct
                    Colors.LightPink;   // Light red for incorrect
            }

            // Always highlight the correct answer in green
            Button? correctButton = GetButtonByOption(CurrentQuestion!.CorrectAnswer);
            if (correctButton != null && correctButton != selectedButton)
            {
                await Task.Delay(500); // Small delay before showing correct answer
                correctButton.BackgroundColor = Colors.LightGreen;
            }
        }

        private Button? GetButtonByOption(string option)
        {
            return option switch
            {
                "A" => this.FindByName<Button>("OptionA"),
                "B" => this.FindByName<Button>("OptionB"),
                "C" => this.FindByName<Button>("OptionC"),
                "D" => this.FindByName<Button>("OptionD"),
                _ => null
            };
        }

        private void ShowFeedback(bool isCorrect)
        {
            var feedbackFrame = this.FindByName<Frame>("FeedbackFrame");
            var feedbackIcon = this.FindByName<Label>("FeedbackIcon");
            var feedbackText = this.FindByName<Label>("FeedbackText");

            if (feedbackFrame != null) feedbackFrame.IsVisible = true;

            if (isCorrect)
            {
                if (feedbackFrame != null) feedbackFrame.BackgroundColor = Colors.LightGreen;
                if (feedbackIcon != null) feedbackIcon.Text = "✅";
                if (feedbackText != null)
                {
                    feedbackText.Text = "Correct! Well done! 🎉";
                    feedbackText.TextColor = Colors.DarkGreen;
                }
            }
            else
            {
                if (feedbackFrame != null) feedbackFrame.BackgroundColor = Colors.LightPink;
                if (feedbackIcon != null) feedbackIcon.Text = "❌";
                if (feedbackText != null)
                {
                    feedbackText.Text = $"Not quite! {CurrentQuestion!.Explanation}";
                    feedbackText.TextColor = Colors.DarkRed;
                }
            }
        }

        private void OnNextQuestion(object sender, EventArgs e)
        {
            _currentQuestionIndex++;
            LoadCurrentQuestion();
            ResetUI();
        }

        private void ShowGameOver()
        {
            var gameOverFrame = this.FindByName<Frame>("GameOverFrame");
            var feedbackFrame = this.FindByName<Frame>("FeedbackFrame");
            var finalScoreLabel = this.FindByName<Label>("FinalScoreLabel");
            var performanceLabel = this.FindByName<Label>("PerformanceLabel");
            var restartButton = this.FindByName<Button>("RestartButton");

            if (gameOverFrame != null) gameOverFrame.IsVisible = true;
            if (feedbackFrame != null) feedbackFrame.IsVisible = false;

            if (finalScoreLabel != null) finalScoreLabel.Text = $"Your Score: {_score}/10";

            // Performance message based on score
            string performanceMessage = _score switch
            {
                10 => "🌟 Perfect! You're a quiz champion! 🌟",
                >= 8 => "🎉 Excellent work! You're amazing! 🎉",
                >= 6 => "👍 Good job! Keep learning! 👍",
                >= 4 => "😊 Not bad! Try again to improve! 😊",
                _ => "🌈 Keep practicing! You'll do better next time! 🌈"
            };

            if (performanceLabel != null) performanceLabel.Text = performanceMessage;
            if (restartButton != null) restartButton.IsVisible = true;
        }

        private void OnRestartQuiz(object sender, EventArgs e)
        {
            InitializeQuiz();
            OnPropertyChanged(nameof(Score));
        }
    }
}