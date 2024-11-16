/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts}"], // Se asegura de que Tailwind revise todos los archivos HTML y TS
  theme: {
    extend: {
      fontFamily: {
        montserrat: ["Montserrat", "sans-serif"],
      },
      backgroundColor: {
        'custom-dark': '#11002E',
      }
    },
  },
  plugins: [
    require("@tailwindcss/typography"), // Mantén el plugin de tipografía
    require("daisyui"), // Mantén el plugin de DaisyUI
    require('@tailwindcss/line-clamp') // Agrega el plugin line-clamp
  ],
  daisyui: {
    themes: ["light", "dark", "cupcake", "pastel"], // Temas de DaisyUI
  },
};
