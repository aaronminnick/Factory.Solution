$("#edit-button").on("click", () => {
  $("#edit-button-div").slideUp(50, () => {$("#editor-div").slideDown(100)})
  ;
});

$("#cancel-edit-button").on("click", () => {
  $("#editor-div").slideUp(50, () => {$("#edit-button-div").slideDown(100)})
  ;
});

$("#delete-button").on("click", () => {
  $("#delete-button-div").slideUp(50, () => {$("#delete-confirm-div").slideDown(100)})
  ;
});

$("#cancel-delete-button").on("click", () => {
  $("#delete-confirm-div").slideUp(50, () => {$("#delete-button-div").slideDown(100)})
  ;
});