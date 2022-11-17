import { teal } from "@mui/material/colors";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { UserProvider } from "./contexts/User";
import { Routes } from "./Routes";

const theme = createTheme({
  palette: {
    primary: teal,
  },
});

function App() {
  return (
    <ThemeProvider theme={theme}>
      <UserProvider>
        <Routes />
      </UserProvider>
    </ThemeProvider>
  );
}

export default App;
