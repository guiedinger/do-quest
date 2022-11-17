import { SxProps, Theme, Typography } from "@mui/material";

interface IPropsLogo {
  primary?: boolean;
  sx?: SxProps<Theme>;
}
export const Logo = ({ primary = false, sx = {} }: IPropsLogo) => {
  return (
    <Typography
      variant="h6"
      component="div"
      color={primary ? "primary" : undefined}
      sx={{ flexGrow: 1, fontFamily: "Retrips", ...sx }}
    >
      DoQuest
    </Typography>
  );
};
