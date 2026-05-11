// @ts-check
//
// The line above enables type checking for this file. Various IDEs interpret
// the @ts-check directive. It will give you helpful autocompletion when
// implementing this exercise.

/**
 * Determines whether or not you need a license to operate a certain kind of vehicle.
 *
 * @param {string} kind
 * @returns {boolean} whether a license is required
 */
const LICENSED_VEHICLES = ["car", "truck"];
export function needsLicense(kind) {
  return LICENSED_VEHICLES.includes(kind);
}

/**
 * Helps choosing between two options by recommending the one that
 * comes first in dictionary order.
 *
 * @param {string} option1
 * @param {string} option2
 * @returns {string} a sentence of advice which option to choose
 */
export function chooseVehicle(option1, option2) {
  var betterOption;
  if(option1>option2){
    betterOption = option2;
  }
  else{
    betterOption = option1;
  }
  return betterOption + " is clearly the better choice.";
}

/**
 * Calculates an estimate for the price of a used vehicle in the dealership
 * based on the original price and the age of the vehicle.
 *
 * @param {number} originalPrice
 * @param {number} age
 * @returns {number} expected resell price in the dealership
 */
export function calculateResellPrice(originalPrice, age) {
  var ageTax;
  if(age<3){
    ageTax = 0.2;
  }
  else if (age>=3 && age<=10){
    ageTax = 0.3;
  }
  else{
    ageTax = 0.5;
  }
  return originalPrice * (1-ageTax);
}
