var gulp = require('gulp');
var $ = require('gulp-load-plugins')({ lazy: true });
var mainBowerFiles = require('main-bower-files');
var filterJS = $.filter('**/*.js');
var filterCSS = $.filter('**/*.css');
var destJS = 'DDDPizzaInc.Api/Scripts/libs/';
var destCSS = 'DDDPizzaInc.Api/Content/';

// JS Task
gulp.task('js', function () {
    gulp.src(mainBowerFiles())
    .pipe(filterJS)
    .pipe($.concat('vendor.js'))
    .pipe($.uglify())
    .pipe(gulp.dest(destJS));
});

// CSS task
gulp.task('css', function () {
    gulp.src(mainBowerFiles())
    .pipe(filterCSS)
    .pipe($.concat('vendor.css'))
    .pipe($.uglifycss())
    .pipe(gulp.dest(destCSS));
});

// Run Default task
gulp.task('default', ['js', 'css'], function () {
    console.log('Running our front end dependencies');
});



