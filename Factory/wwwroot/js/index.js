$("li").filter(function() {
  return this.id.match(/^E/);
}).hover(
  function() {
    $(this).addClass("matched");
    let targets = $(this).data("licenses").toString().split("");
    targets.forEach((target) => {
      $(`#M${target}`).addClass("matched");
    });
  },
  function() {
    $(this).removeClass("matched");
    let targets = $(this).data("licenses").toString().split("");
    console.log(targets);
    targets.forEach((target) => {
      $(`#M${target}`).removeClass("matched");
    });
  }
);

$("li").filter(function() {
  return this.id.match(/^M/);
}).hover(
  function() {
    $(this).addClass("matched");
    let targets = $(this).data("licenses").toString().split("");
    targets.forEach((target) => {
      $(`#E${target}`).addClass("matched");
    });
  },
  function() {
    $(this).removeClass("matched");
    let targets = $(this).data("licenses").toString().split("");
    console.log(targets);
    targets.forEach((target) => {
      $(`#E${target}`).removeClass("matched");
    });
  }
);