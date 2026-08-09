/// <reference path="./global.d.ts" />
// @ts-check

/**
 * Implement the functions needed to solve the exercise here.
 * Do not forget to export them so they are available for the
 * tests. Here an example of the syntax as reminder:
 *
 * export function yourFunction(...) {
 *   ...
 * }
 */

export function cookingStatus(remainingTime){
  if(remainingTime === undefined){
    return 'You forgot to set the timer.';
  }
  else if(remainingTime === 0){
    return 'Lasagna is done.';
  }
  else{
    return 'Not done, please wait.';
  }
}

export function preparationTime(layers, averageTimePerLayer){
  if(averageTimePerLayer === undefined){
    return layers.length * 2;
  }
  else {
    return layers.length * averageTimePerLayer;
  }
}

export function quantities(layers){
  let noodlesLayers = layers.filter(layer => layer === 'noodles');
  let sauceLayers = layers.filter(layer => layer === 'sauce');
  return {noodles: noodlesLayers.length * 50, sauce: sauceLayers.length * 0.2};
}

export function addSecretIngredient(friendsList, myList){
  myList.push(friendsList[friendsList.length - 1]);
}

export function scaleRecipe(recipe, portions){
  let recipeMultiplier = portions/2;
  return Object.fromEntries(
  Object.entries(recipe).map(([key, value]) => [key, value * recipeMultiplier])
);
}