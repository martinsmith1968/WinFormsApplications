# TODO

## Toaster

### Usage Features

- Notifications can be initiated from any corner
- Notifications can be shown on any monitor, or all (Default, All, 1, 2, etc)
- Message box properties can be specified directly :
  - Size
  - Background Colour
  - Background Image
  - Text elements (multiple, named)
    - Font Name, Size, Emohasis
    - Position
    - Alignment
- Message animations can be specified
  - Fade in timespan (or auto)
  - Fade out timespan (or auto)
  - Display timespan

- All of the above can be templated
  - Specify the template name pre-loads the proprties from the template definition
  - Subsequent parameters can then override from the template

### Operational Features

- Multiple instances need to be aware if each other so they do not overlap, but stack up / down / across the screen
  - As older instances close, newer instances roll closer to theor idea; start position
  > Stack Dorection de-endsnt upon display corner ?
  > Q: What happens if there are too many instances to fit in a single lovation ?
    - Display time does not start until they become visible
