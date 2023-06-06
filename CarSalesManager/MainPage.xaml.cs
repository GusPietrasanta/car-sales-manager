// Gus Pietrasanta

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Drawing;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CarSalesManager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Start of additions for part 2 of the app.

        // New constants for optional extras, warranty and insurance.
        
        // Declare rates/percentages for each option.
        const double twoYearsRate = 0.05;
        const double threeYearsRate = 0.1;
        const double fiveYearsRate = 0.2;

        // Declare rates for insurance for both options.
        const double rateUnder25 = 0.2;
        const double rateOver25 = 0.1;
        
        // Set costs for each option.
        const double windowsTintingCost = 150;
        const double ducoProtectionCost = 180;
        const double floorMatsCost = 320;
        const double deluxeSoundSystemCost = 350;

        // End of additions for part 2 of the app.

        // Start of additions for part 3 of the app.
        
        // Declare 3 arrays at the class level.

        private ArrayList namesArrayList = null;
        private ArrayList phoneNumbersArrayList = null;
        private ArrayList vehicleMakesArrayList = null;
        
        // List with 10 random names.
        private ArrayList loadNamesArrayList()
        {
            ArrayList itemsList = new ArrayList();
            itemsList.Add("Emily");
            itemsList.Add("Brooke");
            itemsList.Add("Flynn");
            itemsList.Add("Katie");
            itemsList.Add("Luca");
            itemsList.Add("Tristan");
            itemsList.Add("Evie");
            itemsList.Add("Jessica");
            itemsList.Add("Andrew");
            return itemsList;
        }
                
        // List with 10 random phone numbers.
        private ArrayList loadPhoneNumbersArrayList()
        {
            ArrayList itemsList = new ArrayList();
            itemsList.Add("(08) 8273 4244");
            itemsList.Add("(08) 8255 6946");
            itemsList.Add("(08) 8787 3249");
            itemsList.Add("(08) 8364 3626");
            itemsList.Add("(08) 8253 3492");
            itemsList.Add("(08) 8778 8543");
            itemsList.Add("(08) 8791 2081");
            itemsList.Add("(08) 8322 8180");
            itemsList.Add("(08) 8785 0866");
            return itemsList;
        }
                
        // List with vehicle makes.
        private ArrayList loadVehicleMakesArrayList()
        {
            ArrayList itemsList = new ArrayList();
            itemsList.Add("Toyota");
            itemsList.Add("Holden");
            itemsList.Add("Mitsubishi");
            itemsList.Add("Ford");
            itemsList.Add("BMW");
            itemsList.Add("Mazda");
            itemsList.Add("Volkswagen");
            itemsList.Add("Mini");
            return itemsList;
        }

        // End of additions for part 3 of the app.

        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// This is the function to be run when the save Save button is clicked.
        /// It will:
        ///     - Check that customer name is not empty (or focus on that text box and stop running if it is).
        ///     - Check that customer phone is not empty (or focus on that text box and stop running if it is).
        ///     - Disable customer name text box.
        ///     - Disable customer phone text box.
        ///     - Change some styles to the mentioned text boxes to give them a "locked" look.
        ///     - Focus on the Vehicle Price text box to continue the data input process.
        /// </summary>
        private async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate that the customer name cannot be blank.
            if (customerNameTextBox.Text.Length == 0)
            {
                // Show an error message.
                var dialogMessage = new MessageDialog("Customer Name cannot be blank.");
                await dialogMessage.ShowAsync();
                // Focus on the problematic text box.
                customerNameTextBox.Focus(FocusState.Programmatic);
                // Do not continue running the code.
                return;
            }

            // Validate that the customer phone cannot be blank.
            if (customerPhoneTextBox.Text.Length == 0)
            {
                // Show an error message.
                var dialogMessage = new MessageDialog("Customer Phone cannot be blank");
                await dialogMessage.ShowAsync();
                // Focus on the problematic text box.
                customerPhoneTextBox.Focus(FocusState.Programmatic);
                // Do not continue running the code.
                return;
            }

            // Add new customer to the lists
            namesArrayList.Add(customerNameTextBox.Text);
            phoneNumbersArrayList.Add(customerPhoneTextBox.Text);

            // Call the displayAllCustomers event handler.
            displayAllCustomersButton_Click(null, null);


            // Disable customer name and customer phone textboxes.
            customerNameTextBox.IsReadOnly = true;
            customerPhoneTextBox.IsReadOnly = true;
            
            // Also add some style to make the text boxes look "locked" (Italic, Bold to text, and darker gray for the text box).
            customerNameTextBox.FontStyle = Windows.UI.Text.FontStyle.Italic;
            customerNameTextBox.FontWeight = Windows.UI.Text.FontWeights.Bold;
            customerNameTextBox.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray);
            customerPhoneTextBox.FontStyle = Windows.UI.Text.FontStyle.Italic;
            customerPhoneTextBox.FontWeight = Windows.UI.Text.FontWeights.Bold;
            customerPhoneTextBox.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray);

            // Set focus to the vehicle price text box.
            vehiclePriceTextBox.Focus(FocusState.Programmatic);
        }

        /// <summary>
        /// This is the function to be run when the save Reset button is clicked.
        /// It will:
        ///     - Clear all input text boxes (Customer Name, Customer Phone, Vehicle Price and Trade-In Value).
        ///     - Clear all calculation text boxes (Sub Amount, GST Amount, Final Amount).
        ///     - Re-enable customer name and customer phone text boxes.
        ///     - Focus on customer name text box ready to start data input for a new customer.
        /// </summary>
        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear textboxes:

            // Clear customer name.
            customerNameTextBox.Text = "";

            // Clear customer phone.
            customerPhoneTextBox.Text = "";

            // Clear vehicle price.
            vehiclePriceTextBox.Text = "";

            // Clear trade-in value.
            tradeInTextBox.Text = "";

            // Clear calculation fields:

            // Clear Sub Amount.
            subAmountTextBox.Text = "";

            // Clear GST Amount.
            gstAmountTextBox.Text = "";

            // Clear Final Amount.
            finalAmountTextBox.Text = "";

            // Reset date picker
            collectionDatePicker.Date = DateTime.Today;

            // Reset time picker
            pickUpTimePicker.Time = TimeSpan.Zero;

            // Enable customer name.
            customerNameTextBox.IsReadOnly = false;

            // Enable customer phone.
            customerPhoneTextBox.IsReadOnly = false;

            // Remove styles from customer details text boxes.
            customerNameTextBox.FontStyle = Windows.UI.Text.FontStyle.Normal;
            customerNameTextBox.FontWeight = Windows.UI.Text.FontWeights.Normal;
            customerNameTextBox.Background = new SolidColorBrush(Windows.UI.Colors.LightGray);
            customerPhoneTextBox.FontStyle = Windows.UI.Text.FontStyle.Normal;
            customerPhoneTextBox.FontWeight = Windows.UI.Text.FontWeights.Normal;
            customerPhoneTextBox.Background = new SolidColorBrush(Windows.UI.Colors.LightGray);

            // Return focus to customer name.
            customerNameTextBox.Focus(FocusState.Programmatic);

            // Start of additions for part 2 of the app.

            // Reset Vehicle Warranty to default value (1 Year Warranty).
            vehicleWarrantyComboBox.SelectedIndex = 0;
            windowsTintingCheckBox.IsChecked = false;
            ducoProtectionCheckBox.IsChecked = false;
            floorMatsCheckBox.IsChecked = false;
            deluxeSoundSystemCheckBox.IsChecked = false;

            insurancePolicyToggleSwitch.IsOn = false;

            summaryDetailsTextBlock.Text = "";

            // End of additions for part 2 of the app.

        }

        /// <summary>
        /// This is the function to be run when the save Summary button is clicked.
        /// It will:
        ///     - Use Try-Catch to parse data from input text boxes (showing error messages if data is incorrect).
        ///     - If Trade-In Value is empty, set it to 0.
        ///     - Validate that Vehicle Price is greater than 0.
        ///     - Validate that Trade In Value is greater than or equal to 0.
        ///     - Validate that Vehicle Price is greater than Trade In Value.
        ///     - Make the calculations for Sub Amount, GST Amount, Final Amount, Warranty Cost, Optional Extras and Insurance..
        ///     - Output the calculated values to their respective text boxes.
        /// </summary>
        private async void summaryButton_Click(object sender, RoutedEventArgs e)
        {
            // Constant declaring GST Rate (10%).
            const double GST_RATE = 0.1;

            // To input.
            double vehiclePrice;
            double tradeInValue;

            // To calculate.
            double subAmount;
            double gstAmount;
            double finalAmount;

            // Start of additions for part 2 of the app.

            // New constants for optional extras, warranty and insurance.

            // Variables to calculate.
            double warrantyCost;
            double optionalExtrasCost;
            double insuranceCost;

            // Text for Summary Text Box.
            string summaryText;

            // End of additions for part 2 of the app.

            try
            {
                // Try to convert the Vehicle Price input string to a double datatype value usable for C#.
                vehiclePrice = double.Parse(vehiclePriceTextBox.Text);
            }
            catch (Exception theException)
            {
                // Clear output text boxes to avoid misuse of information from previous valid inputs.
                clearOutputs();
                // Show an error message.
                var dialogMessage = new MessageDialog("Error! Please enter a valid Vehicle Price. " + theException.Message);
                await dialogMessage.ShowAsync();
                // Focus on the text box that is causing the issue.
                vehiclePriceTextBox.Focus(FocusState.Programmatic);
                // Select the value in the appropriate text box to allow quick edit.
                vehiclePriceTextBox.SelectAll();
                // Do not continue with the rest of the code.
                return;
            }


            // If trade-in is empty...
            if (tradeInTextBox.Text.Length == 0)
            {
                // ... then set it to zero.
                tradeInTextBox.Text = "0";
            }

            try
            {
                // Try to convert the Trade-In Value input string to a double datatype value usable for C#.
                tradeInValue = double.Parse(tradeInTextBox.Text);
            }
            catch (Exception theException)
            {
                // Clear output text boxes to avoid misuse of information from previous valid inputs.
                clearOutputs();
                // Show an error message.
                var dialogMessage = new MessageDialog("Error! Please enter a valid Trade-In Value. " + theException.Message);
                await dialogMessage.ShowAsync();
                // Focus on the text box that is causing the issue.
                tradeInTextBox.Focus(FocusState.Programmatic);
                // Select the value in the appropriate text box to allow quick edit.
                tradeInTextBox.SelectAll();
                // Do not continue with the rest of the code.
                return;
            }


            // Validate that vehicle price is greater than 0.

            // Old version:
            // If Vehicle Price IS NOT greater than 0...
            // if (!(vehiclePrice > 0))

            // New version as per suggestion/feedback:
            // If Vehicle price is less than or equal to 0...
            if (vehiclePrice <= 0)
            {
                // ... clear output text boxes to avoid misuse of information from previous valid inputs.
                clearOutputs();
                // Show an error message.
                var dialogMessage = new MessageDialog("Vehicle Price must be greater than 0.");
                await dialogMessage.ShowAsync();
                // Focus on the text box that is causing the issue.
                vehiclePriceTextBox.Focus(FocusState.Programmatic);
                // Select the value in the appropriate text box to allow quick edit.
                vehiclePriceTextBox.SelectAll();
                // Do not continue with the rest of the code.
                return;
            }

            // Validate the tradeIn price is greater than or equal to 0.

            // If Trade In Value is less than 0...
            if (tradeInValue < 0)
            {
                // ... clear output text boxes to avoid misuse of information from previous valid inputs.
                clearOutputs();
                // Show an error message.
                var dialogMessage = new MessageDialog("Trade In Value must be equal or greater than 0.");
                await dialogMessage.ShowAsync();
                // Focus on the text box that is causing the issue.
                tradeInTextBox.Focus(FocusState.Programmatic);
                // Select the value in the appropriate text box to allow quick edit.
                tradeInTextBox.SelectAll();
                // Do not continue with the rest of the code.
                return;
            }

            // Validate the vehicle price is greater that tradeIn price.

            // If Vehicle Price is less than Trade In Value...
            if (vehiclePrice < tradeInValue)
            {
                // ... clear output text box... You get the idea :)
                clearOutputs();
                var dialogMessage = new MessageDialog("Vehicle Price must be greater than Trade In Value.");
                await dialogMessage.ShowAsync();
                tradeInTextBox.Focus(FocusState.Programmatic);
                tradeInTextBox.SelectAll();
                return;
            }

            /// Start of additions for part 2 of the app.

            // Calculate Warranty Cost.
            warrantyCost = calcVehicleWarranty(vehiclePrice);

            // Calculate cost for Optional Extras.
            optionalExtrasCost = calcOptionalExtras();

            // Calculate cost for Insurance Policy.
            insuranceCost = calcAccidentInsurance(vehiclePrice, optionalExtrasCost);

            /// End of additions for part 2 of the app.


            // Calculate and display:

            // Sub Amount (vehicle cost + warranty + extras + insurance  trade-in value).
            subAmount = vehiclePrice + warrantyCost + optionalExtrasCost + insuranceCost - tradeInValue;

            // GST Amount (sub amount * GST Rate).
            gstAmount = subAmount * GST_RATE;

            // Final Amount ( sub amount + GST Amount).
            finalAmount = subAmount + gstAmount;

            // Display calculated Sub Amount into Sub Amount text box converting it to currency format.
            subAmountTextBox.Text = subAmount.ToString("C");

            // Display calculated GST Amount into GST Amount text box converting it to currency format.
            gstAmountTextBox.Text = gstAmount.ToString("C");

            // Display calculated Final Amount into Final Amount text box converting it to currency format.
            finalAmountTextBox.Text = finalAmount.ToString("C");

            summaryText =
                "Customer Name: " + customerNameTextBox.Text +
                "\nCustomer Phone: " + customerPhoneTextBox.Text +
                "\nVehicle Cost: " + vehiclePrice.ToString("C") +
                "\nTrade-In Amount: " + tradeInValue.ToString("C") +
                "\nWarranty Cost: " + warrantyCost.ToString("C") +
                "\nOptional Extras Cost: " + optionalExtrasCost.ToString("C") +
                "\nInsurance Cost: " + insuranceCost.ToString("C") +
                "\nFinal Amount: " + finalAmount.ToString("C");

            summaryDetailsTextBlock.Text = summaryText;

        }

        /// <summary>
        /// This method will clear all the output text boxes and is used when a data input error occurs.
        /// </summary>
        void clearOutputs()
        {
            subAmountTextBox.Text = "";
            gstAmountTextBox.Text = "";
            finalAmountTextBox.Text = "";
        }

        /// <summary>
        /// This method will calculate the insurance cost, considering vehicle price and optionas extras cost.
        /// </summary>
        private double calcAccidentInsurance(double vehiclePrice, double optionalExtras)
        {
            double calculatedInsuranceCost = 0;

            // If the Insurance option is selected...
            if (insurancePolicyToggleSwitch.IsOn == true)
            {
                // Check if the under 25 button is selected...
                if (under25RadioButton.IsChecked == true)
                {
                    // Calculate with the rate for driver under 25 years.
                    calculatedInsuranceCost = (vehiclePrice + optionalExtras) * rateUnder25;
                }
                // Otherwise...
                else
                {
                    // Calculate the rate for driver over 25 years.
                    calculatedInsuranceCost = (vehiclePrice + optionalExtras) * rateOver25;
                }
            }
            // Return the calculated value (will keep 0 if the toggle switch is off).
            return calculatedInsuranceCost;
        }

        /// <summary>
        /// This method will calculate the cost of the warranty depending on how many years were selected, and based on the vehicle price.
        /// </summary>
        private double calcVehicleWarranty(double vehiclePrice)
        {


            // If only one year of warranty was selected.
            if (vehicleWarrantyComboBox.SelectedIndex == 0)
            {
                // Return 0, since no cost is added.
                return 0;
            }
            else if (vehicleWarrantyComboBox.SelectedIndex == 1)
            {
                // Return 5% of vehicle cost (vehicle price * 0.05).
                return vehiclePrice * twoYearsRate;
            }
            else if (vehicleWarrantyComboBox.SelectedIndex == 2)
            {
                // Return 10% of vehicle cost (vehicle price * 0.1).
                return vehiclePrice * threeYearsRate;
            }
            else
            {
                // Return 20% of vehicle cost (vehicle price * 0.2).
                return vehiclePrice * fiveYearsRate;
            }
        }

        /// <summary>
        /// This method will calculate the cost of the selected optional extras.
        /// </summary>
        private double calcOptionalExtras()
        {
            // Initialize the variable that the method will return at the end.
            double optionalsTotalCost = 0;
            
            // Check if the options are checked and add its value to the optionalsTotalCost variable if so.
            if (windowsTintingCheckBox.IsChecked == true)
            {
                optionalsTotalCost = optionalsTotalCost + windowsTintingCost;
            }
            if (ducoProtectionCheckBox.IsChecked == true)
            {
                optionalsTotalCost = optionalsTotalCost + ducoProtectionCost;
            }
            if (floorMatsCheckBox.IsChecked == true)
            {
                optionalsTotalCost = optionalsTotalCost + floorMatsCost;
            }
            if (deluxeSoundSystemCheckBox.IsChecked == true)
            {
                optionalsTotalCost = optionalsTotalCost + deluxeSoundSystemCost;
            }

            // Return the final value of the optionals
            return optionalsTotalCost;
        }

        /// When the ToggleSwitch is turned on or off, this method will disable or enable the radio buttons below it..
        private void insurancePolicyToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (insurancePolicyToggleSwitch.IsOn == true)
            {
                under25RadioButton.IsEnabled = true;
                under25RadioButton.IsChecked = true;
                over25RadioButton.IsEnabled = true;
            }
            else
            {
                under25RadioButton.IsEnabled = false;
                under25RadioButton.IsChecked = false;
                over25RadioButton.IsEnabled = false;
                over25RadioButton.IsChecked = false;
            }
        }


        // Function to be called to show all the customers and their phone numbers.
        private void displayAllCustomersButton_Click(object sender, RoutedEventArgs e)
        {
            // New string to store output message containing names and phone numbers.
            string outputText = "";
            int namesArrayListLength = namesArrayList.Count;

            // Iterate through names and phone numbers lists adding both to the output string.
            for(int i = 0; i < namesArrayListLength; i++)
            {
                outputText = outputText + namesArrayList[i].ToString() + ": " + phoneNumbersArrayList[i] + "\n";
            }

            // Update the Summary Details Text Block with the generated output string.
            summaryDetailsTextBlock.Text = outputText;
            
        }
        // Start of additions for part 3 of the app

        // Event handler to execute when the page is loaded.
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Populate arrays
            namesArrayList = loadNamesArrayList();
            phoneNumbersArrayList = loadPhoneNumbersArrayList();
            vehicleMakesArrayList = loadVehicleMakesArrayList();
        }

        private async void searchNameButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the name from the Customer Name Text Box, and convert it to uppercase to compare.
            string nameToSearch = customerNameTextBox.Text;

            // Check if all the characters in the name are letters, otherwise show a message dialog.
            foreach (char thisChar in nameToSearch)
            {
                if (!Char.IsLetter(thisChar))
                {
                    var dialogMessage = new MessageDialog("Error! Please enter a valid Customer Name.");
                    await dialogMessage.ShowAsync();
                    // Focus on the text box that is causing the issue.
                    customerNameTextBox.Focus(FocusState.Programmatic);
                    // Select the value in the appropriate text box to allow quick edit.
                    customerNameTextBox.SelectAll();
                    // Do not continue with the rest of the code.
                    return;
                }
            }

            // If the Customer Text Box is empty show a message dialog indicating so.
            if (nameToSearch == "")
            {
                // Show an error message
                var dialogMessage = new MessageDialog("Customer name cannot be blank to be searched.");
                await dialogMessage.ShowAsync();
                // Focus on the text box that is causing the issue.
                customerNameTextBox.Focus(FocusState.Programmatic);
                // Select the value in the appropriate text box to allow quick edit.
                customerNameTextBox.SelectAll();
                // Do not continue with the rest of the code.
                return;
            }

            int foundInIndex = searchName(nameToSearch);

            // Call the displayAllCustomers event handler.
            displayAllCustomersButton_Click(null, null);

            // If the name was not found (foundInIndex stayed -1), show a message dialog indicating so.
            if (foundInIndex == -1)
            {
                await errorCustomerNotFound(nameToSearch);
                return;
            }
            // Otherwise, the name was found in the array.
            else

            {
                customerNameTextBox.Text = namesArrayList[foundInIndex].ToString();
                // Call the displayAllCustomers event handler.
                // displayAllCustomersButton_Click(null, null);
                // Get the phone number from the array in the same index as the name was found in, and set customerPhoneTextBox to that value.
                customerPhoneTextBox.Text = phoneNumbersArrayList[foundInIndex].ToString();

                // Disable customer name and customer phone textboxes.
                customerNameTextBox.IsReadOnly = true;
                customerPhoneTextBox.IsReadOnly = true;

                // Also add some style to make the text boxes look "locked" (Italic, Bold to text, and darker gray for the text box).
                customerNameTextBox.FontStyle = Windows.UI.Text.FontStyle.Italic;
                customerNameTextBox.FontWeight = Windows.UI.Text.FontWeights.Bold;
                customerNameTextBox.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray);
                customerPhoneTextBox.FontStyle = Windows.UI.Text.FontStyle.Italic;
                customerPhoneTextBox.FontWeight = Windows.UI.Text.FontWeights.Bold;
                customerPhoneTextBox.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray);

                // Set focus to the vehicle price text box.
                vehiclePriceTextBox.Focus(FocusState.Programmatic);
            }

        }

        private async Task errorCustomerNotFound(string nameBeingSearched)
        {
            var dialogMessage = new MessageDialog("Customer '" + nameBeingSearched + "' not found.");
            await dialogMessage.ShowAsync();
            // Focus on the text box that is causing the issue.
            customerNameTextBox.Focus(FocusState.Programmatic);
            // Select the value in the appropriate text box to allow quick edit.
            customerNameTextBox.SelectAll();
            // Do not continue with the rest of the code.
            return;
        }

        private async void deleteName_Click(object sender, RoutedEventArgs e)
        {
            // Get the name from the Customer Name Text Box, and convert it to uppercase to compare.
            string nameToDelete = customerNameTextBox.Text;

            // If the Customer Text Box is empty show a message dialog indicating so.
            if (nameToDelete == "")
            {
                // Show an error message.
                var dialogMessage = new MessageDialog("Customer name cannot be blank to be deleted.");
                await dialogMessage.ShowAsync();
                // Focus on the text box that is causing the issue.
                customerNameTextBox.Focus(FocusState.Programmatic);
                // Select the value in the appropriate text box to allow quick edit.
                customerNameTextBox.SelectAll();
                // Do not continue with the rest of the code.
                return;
            }

            int foundInIndex = searchName(nameToDelete);

            // If the name was not found (foundInIndex stayed -1), show a message dialog indicating so.
            if (foundInIndex == -1)
            {
                await errorCustomerNotFound(nameToDelete);
                return;
            }
            // Otherwise, the name was found in the array.
            // Proceed to delete it, and update the Summary Details TextBlock.
            else
            {
                // Delete customer from the names and phone numbers lists.
                namesArrayList.RemoveAt(foundInIndex);
                string deletedPhoneNumber = phoneNumbersArrayList[foundInIndex].ToString();
                phoneNumbersArrayList.RemoveAt(foundInIndex);

                // Clear customer phone TextBox
                customerPhoneTextBox.Text = "";
                // Focus on name TextBox and select all
                customerNameTextBox.Focus(FocusState.Programmatic);
                customerNameTextBox.SelectAll();

                // Call the displayAllCustomers event handler.
                displayAllCustomersButton_Click(null, null);

                // Output a message to confirm which name and number have been deleted and the new legth of the array.
                int arrayLength = namesArrayList.Count;
                var dialogMessage = new MessageDialog("Customer " + nameToDelete + " with phone number " + deletedPhoneNumber + " was deleted. The new length of the list is " + arrayLength.ToString() + ".");
                await dialogMessage.ShowAsync();

            }
        }

        private void displayAllMakesButton_Click(object sender, RoutedEventArgs e)
        {
            // Initialize a new empty string.
            string outputText = "";

            // Sort the vehicleMakesArray.
            vehicleMakesArrayList.Sort();

            // 
            int vehicleMakesLength = vehicleMakesArrayList.Count;

            // Add each vehicle make to the output string.
            for(int i = 0; i < vehicleMakesLength; i++)
            {
                outputText = outputText + vehicleMakesArrayList[i].ToString() + "\n";
            }
            // Update Summary Details Text Block.
            summaryDetailsTextBlock.Text = outputText;
        }

        private async void binarySearchMakeButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the vehicle make to search from the vehicle make text box.
            string makeToSearch = vehicleMakeTextBox.Text;

            // If vehicleMakeTextBox is empty...
            if (makeToSearch == "")
            {
                // Show an error message
                var dialogMessage = new MessageDialog("Vehicle make name cannot be blank to be searched.");
                await dialogMessage.ShowAsync();
                // Focus on the text box that is causing the issue.
                customerNameTextBox.Focus(FocusState.Programmatic);
                // Select the value in the appropriate text box to allow quick edit.
                customerNameTextBox.SelectAll();
                // Do not continue with the rest of the code.
                return;
            }

            // Sort the vehicle makes array list.
            vehicleMakesArrayList.Sort();

            // Call the binary search function.
            int foundInIndex = binarySearchVehicleMakes(makeToSearch);

            // If the vehicle make was not found...
            if (foundInIndex == -1)
            {
                // Show a message dialog saying so.
                var dialogMessage = new MessageDialog("The vehicle make '" + makeToSearch + "' was not found.");
                await dialogMessage.ShowAsync();
                vehicleMakeTextBox.Focus(FocusState.Programmatic);
                vehicleMakeTextBox.SelectAll();
                displayAllMakesButton_Click(null, null);
                return;
            }
            // Otherwise show a message dialog with the index it was found at.
            else
            {
                displayAllMakesButton_Click(null, null);
                var dialogMessage = new MessageDialog("The vehicle make '" + makeToSearch + "' was found at index " + foundInIndex + " (" + (foundInIndex + 1) + " in the list).");
                await dialogMessage.ShowAsync();
                vehicleMakeTextBox.Focus(FocusState.Programmatic);
                vehicleMakeTextBox.SelectAll();
                return;
            }
        }

        private async void insertMakeButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the vehicle make to add.
            string newVehicleMakeToAdd = vehicleMakeTextBox.Text;

            if(newVehicleMakeToAdd == "")
            {
                var dialogMessage = new MessageDialog("The vehicle make cannot be blank to be added.");
                await dialogMessage.ShowAsync();
                vehicleMakeTextBox.Focus(FocusState.Programmatic);
                vehicleMakeTextBox.SelectAll();
                return;
            }


            char firstLetter = char.ToUpper(newVehicleMakeToAdd[0]);
            newVehicleMakeToAdd = newVehicleMakeToAdd.Replace(newVehicleMakeToAdd[0], firstLetter);

            // Call the binary search function.
            int foundInIndex = binarySearchVehicleMakes(newVehicleMakeToAdd);

            // If the returned value is -1 (not found), that means that the vehicle make is not in the list.
            if(foundInIndex == -1)
            {
                vehicleMakeTextBox.Focus(FocusState.Programmatic);
                vehicleMakeTextBox.SelectAll();
                // Add the vehicle make to the list.
                vehicleMakesArrayList.Add(newVehicleMakeToAdd);
                // Sort the vehicle makes list.
                vehicleMakesArrayList.Sort();
                // Display all the make in the Summary Details TextBlock.
                displayAllMakesButton_Click(null, null);
                
            }
            else
            {
                // Otherwise, show a message dialog saying that the vehicle make is in the list already.
                var dialogMessage = new MessageDialog("The vehicle make '" +  newVehicleMakeToAdd + "' already exists.");
                await dialogMessage.ShowAsync();
                vehicleMakeTextBox.Focus(FocusState.Programmatic);
                vehicleMakeTextBox.SelectAll();
                return;
            }
        }

        /// <summary>
        /// This method will perform a binary search through the vehicleMakesArrayList.
        /// </summary>
        /// <param name="makeToSearch"></param>
        /// <returns>Index of the list were the vehicle make was found at, or -1 if it was not found.</returns>
        private int binarySearchVehicleMakes(string makeToSearch)
        {
            // Convert passed parameter to uppercase to compare
            makeToSearch = makeToSearch.ToUpper();

            // Binary search!
            int foundInIndex = -1;
            int min = 0;
            int max = vehicleMakesArrayList.Count - 1;
            int actual = (max + min) / 2;
            while (min <= max)
            {
                string makeToCompareAgainstTo = vehicleMakesArrayList[actual].ToString().ToUpper();

                if (makeToSearch == makeToCompareAgainstTo)
                {
                    foundInIndex = actual;
                    break;
                }
                else if (String.Compare(makeToSearch, makeToCompareAgainstTo) == -1)
                {
                    max = actual - 1;
                    actual = (max + min) / 2;
                }
                else
                {
                    min = actual + 1;
                    actual = (max + min) / 2;
                }
            }
            return foundInIndex;
        }

        /// <summary>
        /// This method will search for the name passed as parameter in the namesArrayList.
        /// </summary>
        /// <param name="nameToSearch"></param>
        /// <returns>Index of the list were the name was found at, or -1 if it was not found.</returns>
        private int searchName(string nameToSearch)
        {
            // Convert passed parameter to uppercase to compare
            nameToSearch = nameToSearch.ToUpper();
            // Store namesArrayList length
            int namesArrayListLength = namesArrayList.Count;

            // Initialize a new int as -1. It will be modified if the name is found in the array.
            // Otherwise, it will stay as -1, indicating that the name was not found.
            int foundInIndex = -1;

            // Sequential search:
            for (int searchIndex = 0; searchIndex < namesArrayListLength; searchIndex++)
            {
                // If name is found in any of the elements of the namesArrayList...
                if (nameToSearch == namesArrayList[searchIndex].ToString().ToUpper())
                {
                    // Set foundInIndex to that searchIndex.
                    foundInIndex = searchIndex;
                    break;
                }
            }

            return foundInIndex;
        }
    }
}
