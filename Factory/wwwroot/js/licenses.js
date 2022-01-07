$(".remove-license-button").on("click", function(event) {
  event.preventDefault();
  let engineerId = $(this).siblings(".engineer-id").val();
  let machineId = $(this).siblings(".machine-id").val();
  $("#licenses-div").load("../RemoveLicense", {EngineerId: engineerId, MachineId: machineId})
});

$(".add-license-button").on("click", function(event) {
  event.preventDefault();
  let engineerId = $(this).siblings(".engineer-id").val();
  let machineId = $(this).siblings(".machine-id").val();
  $("#licenses-div").load("../AddLicense", {EngineerId: engineerId, MachineId: machineId})
});