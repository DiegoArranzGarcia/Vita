const replace = require('gulp-replace');
const { src, dest, series, task } = require('gulp');

function tokenize(cb) {
  src(['dist/assets/app-settings.json'])
    .pipe(replace(/"(.*?)": "(.*?)"/g, '"$1": "__$1__"'))
    .pipe(dest(['dist/assets']));

  cb();
}

exports.tokenize = tokenize;
