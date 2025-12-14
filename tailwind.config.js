/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./index.html",
    "./App.razor",

    // Pages
    "./Pages/**/*.{razor,html,cshtml}",

    // Components trong thư mục Home
    "./Components/Home/**/*.{razor,html,cshtml}",

    // Components khác
    "./Components/**/*.{razor,html,cshtml}",

    // Shared layout
    "./Shared/**/*.{razor,html,cshtml}",
  ],
  theme: {
    extend: {},
  },
  plugins: [],
};
