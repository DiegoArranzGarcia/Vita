const replace = require('gulp-replace');
const { src, dest, series, task } = require('gulp');

function tokenize(cb) {
  src(['dist/assets/*.json'])
    .pipe(
      replace(/"(.*?)": "(.*?)"/g, function (match, p1, p2) {
        console.log(`Tokenizing setting: '${p1}'`);
        return `"${p1}": "__${p1}__"`;
      })
    )
    .pipe(dest(['dist/assets']));

  cb();
}

exports.tokenize = tokenize;
