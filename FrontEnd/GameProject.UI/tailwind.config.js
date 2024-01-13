/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}"
  ],
  theme: {
    extend: {
      backgroundImage: {
        'sony': "url('assets/images/sony.jpeg')",
        'microsoft': "url('assets/images/microsoft.png')"
      },
      backgroundAttachment: {
        'fixed': 'fixed',
      },
    },
  },
  plugins: [require("daisyui")],
  daisyui: {
    themes: [
      {
        sonytheme: {
          "primary": "#1d4ed8",
          "secondary": "#2563eb",
          "accent": "#1d4ed8",
          "neutral": "#000000",
          "base-100": "#d1d5db",
          "info": "#1d4ed8",
          "success": "#15803d",
          "warning": "#b45309",
          "error": "#be123c",
          "background-attachment": "fixed"
        },
        microsofttheme: {
          "primary": "#107b10",
          "secondary": "#166534",
          "accent": "#65a30d",
          "neutral": "#ffffff",
          "base-100": "#171717",
          "info": "#1d4ed8",
          "success": "#15803d",
          "warning": "#b45309",
          "error": "#be123c",
          "background-attachment": "fixed"
        }
      },
    ]
  }
}

