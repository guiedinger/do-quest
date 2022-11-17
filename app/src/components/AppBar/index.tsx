import { Button, Container, Toolbar, AppBar as MuiAppBar } from "@mui/material";
import useUser from "../../hooks/useUser";
import { Logo } from "../Logo";

export const AppBar = () => {
  const { signOut } = useUser();
  return (
    <MuiAppBar position="static">
      <Container maxWidth="md">
        <Toolbar>
          <Logo />
          <Button color="inherit" onClick={signOut}>
            Logout
          </Button>
        </Toolbar>
      </Container>
    </MuiAppBar>
  );
};
