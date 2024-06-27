using POE_ST10393673_PROG6221.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;


namespace POE_ST10393673_PROG6221.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _recipeName;
        public string RecipeName
        {
            get { return _recipeName; }
            set
            {
                _recipeName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RecipeName)));
            }
        }

        private Ingredient _newIngredient = new Ingredient();
        public Ingredient NewIngredient
        {
            get { return _newIngredient; }
            set
            {
                _newIngredient = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewIngredient)));
            }
        }

        private string _newRecipeInstruction;
        public string NewRecipeInstruction
        {
            get { return _newRecipeInstruction; }
            set
            {
                _newRecipeInstruction = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewRecipeInstruction)));
            }
        }

        private ObservableCollection<Recipe> _recipes = new ObservableCollection<Recipe>();
        public ObservableCollection<Recipe> Recipes
        {
            get { return _recipes; }
            set
            {
                _recipes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Recipes)));
            }
        }

        private Recipe _selectedRecipe;
        public Recipe SelectedRecipe
        {
            get { return _selectedRecipe; }
            set
            {
                _selectedRecipe = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedRecipe)));
            }
        }

        public ObservableCollection<string> Measurements { get; set; } = new ObservableCollection<string>
        {
            "Teaspoon", "Tablespoon", "Cup", "Ounce", "Gram", "Kilogram"
        };

        public ObservableCollection<string> FoodGroups { get; set; } = new ObservableCollection<string>
        {
            "Vegetables", "Fruits", "Dairy", "Grains", "Protein"
        };

        public ICommand AddIngredientCommand { get; set; }
        public ICommand SaveInstructionsCommand { get; set; }

        // Constructor
        public MainViewModel()
        {
            AddIngredientCommand = new RelayCommand(AddIngredient);
            SaveInstructionsCommand = new RelayCommand(SaveInstructions);
        }

        private void AddIngredient(object parameter)
        {
            if (SelectedRecipe != null)
            {
                SelectedRecipe.Ingredients.Add(new Ingredient
                {
                    Name = NewIngredient.Name,
                    Quantity = NewIngredient.Quantity,
                    Unit = NewIngredient.Unit,
                    Calories = NewIngredient.Calories,
                    FoodGroup = NewIngredient.FoodGroup
                });
                NewIngredient = new Ingredient(); // Clear input fields after adding ingredient
            }
        }

        private void SaveInstructions(object parameter)
        {
            if (SelectedRecipe != null && !string.IsNullOrEmpty(NewRecipeInstruction))
            {
                SelectedRecipe.Instructions.Add(NewRecipeInstruction);
                NewRecipeInstruction = string.Empty; // Clear input field after saving instruction
            }
        }
    }
}
