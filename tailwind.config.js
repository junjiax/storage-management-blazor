/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./wwwroot/index.html",
    "./Pages/**/*.{razor,html}",
    "./Layout/**/*.{razor,html}",
    "./Shared/**/*.{razor,html}",
    "./**/*.razor",
  ],
  darkMode: "class",
  theme: {
    extend: {},
  },
  plugins: [],
};
