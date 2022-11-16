import { teal } from "@mui/material/colors";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { Template } from "./components/Template";
import { Routes } from "./Routes";

const theme = createTheme({
  palette: {
    primary: teal,
  },
});

function App() {
  return (
    <ThemeProvider theme={theme}>
      <Routes />
    </ThemeProvider>
  );
}

export default App;
