/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {},
  },
  plugins: [require("daisyui")],
  daisyui: {
    themes: [
      {
        sonytheme: {
          "primary": "#1d4ed8",
          "secondary": "#2563eb",
          "accent": "#1d4ed8",
          "neutral": "#1d4ed8",
          "base-100": "#d1d5db",
          "info": "#1d4ed8",
          "success": "#15803d",
          "warning": "#b45309",
          "error": "#be123c",
        },
      },]
  }
}

