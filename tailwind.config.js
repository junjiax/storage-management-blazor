/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
        "./wwwroot/index.html",
        "./Pages/**/*.{razor,razor.cs,html}",
        "./Layout/**/*.{razor,razor.cs,html}",
        "./Shared/**/*.{razor,razor.cs,html}",
        "./Components/**/*.{razor,razor.cs,html}",
        "./**/*.{razor,razor.cs,html}"
  ],
  darkMode: "class",
  theme: {
    extend: {},
  },
  plugins: [],
};
