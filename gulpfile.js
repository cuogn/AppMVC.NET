const gulp = require("gulp");
const cleanCSS = require("gulp-clean-css");
const sass = require("gulp-sass")(require("sass"));
const postcss = require("gulp-postcss");
const autoprefixer = require("autoprefixer");
const log = require("gulplog");
const PluginError = require("plugin-error");
const rename = require("gulp-rename");

gulp.task("default", function () {
  return (
    gulp
      .src("assets/scss/site.scss")
      .pipe(
        sass().on("error", function (err) {
          throw new PluginError("sass", err.message);
        })
      )
      .pipe(postcss([autoprefixer()]))
      //   .pipe(cleanCSS({ compatibility: "ie8" }))
      // .pipe(rename({ suffix: ".min" }))
      .pipe(gulp.dest("wwwroot/css"))
      .on("end", () =>
        log.info("CSS đã được biên dịch và giảm thiểu thành công!")
      )
  );
});

gulp.task("watch", function () {
  gulp.watch("assets/scss/*.scss", gulp.series("default"));
});
